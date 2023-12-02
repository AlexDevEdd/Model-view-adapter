using System.Collections.Generic;
using Practice.Core.Interfaces;
using Practice.Tools;

namespace Practice.Effects
{
    public sealed class EffectSystem
    {
        private readonly EffectFactory _effectFactory;

        private readonly Dictionary<EffectType, IEffectPresenter> _effects = new();

        public EffectSystem(EffectFactory effectFactory)
        {
            _effectFactory = effectFactory;
        }

        public void TryApplyOrCreateEffect(EffectType type)
        {
            if (!_effects.TryGetValue(type, out var effect)) 
                CreateEffect(type);
            else
                effect.Effect.IncreaseEffectValue();
        }
        
        public void TryRemoveEffect(EffectType type)
        {
            if (_effects.TryGetValue(type, out var effect)) 
                RemoveEffect(type, effect);
            else
                Log.ColorLogDebugOnly($"you're trying to remove an effect that doesn't exist type of {type}", 
                    ColorType.Red);
        }
        
        private void CreateEffect(EffectType type)
        {
            var effect = _effectFactory.CreateEffect(type);
            _effects.Add(type, effect);
        }
        
        private void RemoveEffect(EffectType type, IEffectPresenter effect)
        {
            effect.Dispose();
            _effectFactory.RemoveEffect(effect);
            _effects.Remove(type);
        }
    }
}