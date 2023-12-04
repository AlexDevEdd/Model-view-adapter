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
        
        private readonly GameConfigs _configs;
        private readonly Pool<EffectView> _pool;

        public EffectFactory(GameConfigs configs, GameResources resources, Transform container, Transform parent)
        {
            _configs = configs;
            _pool = new Pool<EffectView>(resources.EffectPrefab, POOL_SIZE, container, parent);
        }

        public IEffectPresenter CreateEffect(EffectType type)
        {
            var config = GetConfigByType(type);
            var effect = CreateEffect(config);
            var view = SpawnView();
            return CreatePresenter(effect, view);
        }

        public void RemoveEffect(IEffectPresenter effect) 
            => _pool.DeSpawn(effect.GetEffectView());

        private EffectView SpawnView() 
            => _pool.Spawn();

        private IEffectPresenter CreatePresenter(Effect effect, EffectView view)
            => new EffectPresenter(effect, view);

        private Effect CreateEffect(EffectConfig config)
            => new(config.InitValue, config.IncreaseValue, config.Icon, config.Color);

        private EffectConfig GetConfigByType(EffectType type) 
            => _configs.EffectConfigs.GetConfigByType(type);
    }
}