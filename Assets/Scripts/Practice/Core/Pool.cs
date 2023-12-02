using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

namespace Practice.Core
{
    public class Pool<T>  where T: MonoBehaviour
    {
        private readonly Queue<T> _pool = new();
        private readonly HashSet<T> _actives = new();
        
        private readonly T _prefab;
        private readonly int _size;
        
        private readonly Transform _parent;
        private Transform _container;

        public Pool(T prefab, int size, Transform root, Transform parent = null)
        {
            _prefab = prefab;
            _size = size;
            _parent = parent;
            Init(root);
        }

        private void Init(Transform root)
        {
            for (var i = 0; i < _size; i++)
            {
                if (_container == null)
                {
                    _container = new GameObject($"{typeof(T)}s").transform;
                    _container.SetParent(root);
                }

                var obj = CreateObj();
                HIde(obj);
                _pool.Enqueue(obj);
            }
        }

        public T Spawn()
        {
            if (_pool.TryDequeue(out var obj))
                Show(obj);
            else
            {
                obj = CreateObj();
                Show(obj);
            }
            
            return obj;
        }
        
        public void DeSpawn(T obj)
        {
            if (_actives.Remove(obj))
            {
                HIde(obj);
                _pool.Enqueue(obj);
            }
        }

        public void DeSpawnAll()
        {
            _actives.ForEach(obj =>
            {
                if (obj != null)
                {
                    HIde(obj);
                    _pool.Enqueue(obj);
                }
            });
            _actives.Clear();
        }

        private void HIde(T obj)
        {
            obj.gameObject.SetActive(false);
            obj.gameObject.transform.SetParent(_container);
        }
        
        private void Show(T obj)
        {
            _actives.Add(obj);
            if(_parent != null)
                obj.gameObject.transform.SetParent(_parent);
            
            obj.gameObject.SetActive(true);
        }
        
        private T CreateObj()
            => Object.Instantiate(_prefab, _container);
    }
}