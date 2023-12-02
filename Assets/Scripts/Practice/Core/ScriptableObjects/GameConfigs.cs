using System;
using Practice.Core.CustomStructures;
using Sirenix.OdinInspector;

namespace Practice.Core.ScriptableObjects
{
    [Serializable]
    public class GameConfigs
    {
        [Title("Effect configuration", TitleAlignment = TitleAlignments.Centered)]
        public EffectConfigs EffectConfigs;
    }
}