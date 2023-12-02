using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Practice
{
    public sealed class EffectSystem : MonoBehaviour
    {
        private EffectStorage _storage;
        private EffectFactory _factory;

        [Inject]
        public void Construct(EffectStorage storage, EffectFactory factory)
        {
            _storage = storage;
            _factory = factory;
        }

        [Button]
        public void AddEnergy()
        {
           var effect = _factory.Create(EffectType.Energy);
           _storage.AddEffect(effect);
        }
        
        [Button]
        public void AddAttack()
        {
            var effect = _factory.Create(EffectType.Attack);
            _storage.AddEffect(effect);
        }

        [Button]
        public void AddMoney()
        {
            var effect = _factory.Create(EffectType.Money);
            _storage.AddEffect(effect);
        }
    }
}