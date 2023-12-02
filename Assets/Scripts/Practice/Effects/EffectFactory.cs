using Practice.Core;
using Practice.Core.CustomStructures;
using Practice.Core.Interfaces;
using Practice.Core.ScriptableObjects;
using UnityEngine;

namespace Practice.Effects
{
    public sealed class EffectFactory
    {
        private const int POOL_SIZE = 10;

        private readonly EffectStorage _effectStorage;
        private readonly GameConfigs _configs;
        
        private readonly Pool<EffectView> _pool;

        public EffectFactory(EffectStorage effectStorage, GameConfigs configs,
            GameResources resources, Transform container, Transform parent)
        {
            _configs = configs;
            _effectStorage = effectStorage;
            _pool = new Pool<EffectView>(resources.EffectPrefab, POOL_SIZE, container, parent);
        }

        public IEffectPresenter CreateEffect(EffectType type)
        {
            var config = GetConfigByType(type);
            var effect = CreateEffect(config);
            var view = SpawnView();
            _effectStorage.AddEffect(effect);
            return CreatePresenter(effect, view, _effectStorage);
        }

        public void RemoveEffect(IEffectPresenter effect)
        {
            _effectStorage.RemoveEffect(effect.Effect); 
            _pool.DeSpawn(effect.View);
        } 

        private EffectView SpawnView() 
            => _pool.Spawn();

        private IEffectPresenter CreatePresenter(Effect effect, EffectView view, EffectStorage storage) =>
            new EffectPresenter(effect, view, storage);
        
        private Effect CreateEffect(EffectConfig config) =>
            new(config.InitValue, config.IncreaseValue, config.Icon, config.Color);

        private EffectConfig GetConfigByType(EffectType type)
            => _configs.EffectConfigs.GetConfigByType(type);
    }
}