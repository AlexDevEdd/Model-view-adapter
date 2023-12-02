using System.Collections.Generic;
using System.Linq;
using Practice.ScriptableObjects;
using UnityEngine;

namespace Practice
{
    public sealed class EffectManager
    {
        private readonly EffectConfigsSO _configs;
        private readonly EffectCollection _effectStorage;
        private readonly Dictionary<EffectType, Effect> _effects = new();

        public EffectManager(EffectConfigsSO configs, EffectCollection effectStorage)
        {
            _configs = configs;
            _effectStorage = effectStorage;
        }

        public void ApplyEffect(EffectType type)
        {
            if (_effects.TryGetValue(type, out var effect))
            {
                if (_effectStorage.GetEffects().Contains(effect))
                {
                    float addValue = _configs.GetConfigByType(type).InitValue;
                    effect.SetValue(effect.Value + addValue);
                }
                else
                    _effectStorage.AddEffect(effect);
            }
            else
            {
                Debug.LogError($"[EffectManager]: Can't Apply [{type}] Effect< because it is not initialized");
            }
        }
        
        public Effect CreateEffect(EffectType type)
        {
            var config = _configs.GetConfigByType(type);
            var effect = new Effect(config.InitValue, config.Icon, config.Color);
            _effects.Add(type, effect);
            return effect;
        }

        public void RemoveEffect(EffectType type)
        {
            if (!_effects.TryGetValue(type, out var effect))
            {
                Debug.LogWarning($"[EffectManager]: Effect [{type}] not applied, Can't remove it");
                return;
            }
            
            effect.SetValue(_configs.GetInitValueByType(type));
            _effectStorage.RemoveEffect(effect);
        }
    }
}