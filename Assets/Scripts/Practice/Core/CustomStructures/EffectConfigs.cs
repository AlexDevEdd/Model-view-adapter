using System;
using System.Collections.Generic;
using System.Linq;
using Practice.Effects;

namespace Practice.Core.CustomStructures
{
    [Serializable]
    public class EffectConfigs
    {
        public List<EffectConfig> Configs;
        
        public EffectConfig GetConfigByType(EffectType type)
        {
            return Configs.FirstOrDefault(e => e.Type == type);
        }
    }
}