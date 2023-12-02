using System.Collections.Generic;
using Practice.ScriptableObjects;

namespace Practice
{
    public sealed class EffectFactory
    {
        private readonly EffectConfigs _configs;
        private readonly Dictionary<EffectType, Effect> _effects = new();
        
        public Dictionary<EffectType, Effect> Effects => _effects;
        
        public EffectFactory(EffectConfigs configs)
        {
            _configs = configs;
        }
        
        public Effect Create(EffectType type)
        {
            if (!_effects.TryGetValue(type, out var effect))
            {
                var config = _configs.GetConfigByType(type);
                effect = new Effect(config.Value, config.IncreaseValue, config.Icon, config.Color);
                _effects.TryAdd(type,effect);
            }
            
            return effect;
        }
    }
}