using System.Collections.Generic;
using Practice.ScriptableObjects;
using UnityEngine;

namespace Practice
{
    public sealed class EffectManager
    {
        private readonly EffectConfigsSO _configs;
        private readonly EffectStorage _effectStorage;
        private readonly EffectProvider _effectProvider;
        private readonly Dictionary<EffectType, Effect> _effects = new();
        private List<EffectPresenter> _presenters = new ();

        public EffectManager(EffectConfigsSO configs, EffectStorage effectStorage, EffectProvider effectProvider)
        {
            _configs = configs;
            _effectStorage = effectStorage;
            _effectProvider = effectProvider;
        }
        
        public void ApplyEffect(EffectType type)
        {
            if (!_effects.TryGetValue(type, out var effect))
            {
                effect = CreateEffect(type);
                _presenters.Add(new EffectPresenter(effect, _effectProvider.GetEffectView(type), _effectStorage));
            }
            _effectStorage.AddEffect(effect);
        }

        private Effect CreateEffect(EffectType type)
        {
            var config = _configs.GetConfigByType(type);
            var effect = new Effect(config.InitValue, config.IncreaseValue, config.Icon, config.Color);
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