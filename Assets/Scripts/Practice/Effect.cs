using System;
using UnityEngine;

namespace Practice
{
    public class Effect
    {
        public event Action<float> OnValueChanged;
        
        public float Value { get; private set; }
        public Sprite Icon { get; }
        public Color Color { get; }
    
        public void SetValue(float value)
        {
            Value = value;
            OnValueChanged?.Invoke(Value);
        }

        public Effect(float value, Sprite icon, Color color)
        {
            Value = value;
            Icon = icon;
            Color = color;
        }
    }
}