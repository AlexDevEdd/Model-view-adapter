﻿using System;
using System.Collections.Generic;

namespace Practice.Effects
{
    public sealed class EffectStorage
    {
        public event Action<Effect> OnAdded;
        public event Action<Effect> OnRemoved;

        public int Count => _effects.Count;

        private readonly HashSet<Effect> _effects = new();
        
        public void AddEffect(Effect effect)
        {
            if (_effects.Add(effect)) 
                OnAdded?.Invoke(effect);
        }
        
        public void RemoveEffect(Effect effect)
        {
            if (_effects.Remove(effect)) 
                OnRemoved?.Invoke(effect);
        }

        public IEnumerable<Effect> GetEffects() 
            => _effects;
    }
}