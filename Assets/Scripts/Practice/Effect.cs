using System;
using UnityEngine;

namespace Practice
{
    public class Effect
    {
        public event Action<float> OnValueChanged;
        
        public float Value { get; private set; }
        public float IncreaseValue { get; }
        public Sprite Icon { get; }
        public Color Color { get; }
    
        public void SetValue(float value)
        {
            Value = value;
            OnValueChanged?.Invoke(Value);
        }

        public void IncreaseEffectValue() => SetValue(Value + IncreaseValue);

        public Effect(float value, float increaseValue, Sprite icon, Color color)
        {
            Value = value;
            IncreaseValue = increaseValue;
            Icon = icon;
            Color = color;
        }
    }
}