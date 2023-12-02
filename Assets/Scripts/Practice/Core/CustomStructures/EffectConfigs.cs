using System;
using System.Collections.Generic;
using System.Linq;
using Practice.Core.ScriptableObjects;
using Practice.Effects;

namespace Practice.Core.CustomStructures
{
    [Serializable]
    public class EffectConfigs
    {
        public List<EffectConfig> Configs;
        
        public EffectConfig GetConfigByType(EffectType type)
            => Configs.FirstOrDefault(e => e.Type == type);

        public float GetInitValueByType(EffectType type)
            => Configs.FirstOrDefault(e => e.Type == type).InitValue;
    }
}