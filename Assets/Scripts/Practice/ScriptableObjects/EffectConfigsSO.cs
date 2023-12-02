using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Practice.ScriptableObjects
{
    [CreateAssetMenu(fileName = "EffectConfigs", menuName = "EffectConfigs")]
    public class EffectConfigsSO : ScriptableObject
    {
        [Title("Effect configuration", TitleAlignment = TitleAlignments.Centered)]
        public List<EffectConfig> EffectConfig;

        public EffectConfig GetConfigByType(EffectType type) => EffectConfig.FirstOrDefault(e => e.Type == type);

        public float GetInitValueByType(EffectType type) => EffectConfig.FirstOrDefault(e => e.Type == type).InitValue;
    }
    
    [Serializable]
    public struct EffectConfig
    {
        public EffectType Type;
        public float InitValue;
        public Sprite Icon;
        public Color Color;
    }
}