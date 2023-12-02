using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Practice.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EffectConfigs", menuName = "EffectConfigs")]
    public class EffectConfigs : ScriptableObject
    {
        [Title("Effect configuration", TitleAlignment = TitleAlignments.Centered)]
        public List<EffectConfig> EffectConfig;

        public EffectConfig GetConfigByType(EffectType type)
            => EffectConfig.FirstOrDefault(e => e.Type == type);
    }
    
    [Serializable]
    public struct EffectConfig
    {
        public EffectType Type;
        public float Value;
        public float IncreaseValue;
        public Sprite Icon;
        public Color Color;
    }
}