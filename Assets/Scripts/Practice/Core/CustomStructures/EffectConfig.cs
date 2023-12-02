using System;
using Practice.Effects;
using UnityEngine;

namespace Practice.Core.CustomStructures
{
    [Serializable]
    public struct EffectConfig
    {
        public EffectType Type;
        public float InitValue;
        public float IncreaseValue;
        public Sprite Icon;
        public Color Color;
    }
}