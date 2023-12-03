using System;
using System.Collections.Generic;
using System.Linq;
using Practice.Effects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Practice.Core.ScriptableObjects
{
    [Serializable]
    public class GameResources
    {
        [Title("Icons", TitleAlignment = TitleAlignments.Centered)]
        [SerializeField] private List<Sprite> _icons;
        [SerializeField] private Sprite _placeholder;
        
        [Title("Effect View", TitleAlignment = TitleAlignments.Centered)]
        [SerializeField] public EffectView EffectPrefab;
        
        public Sprite GetSprite(string key)
        {
            var result = _icons.FirstOrDefault(s => s.name == key);
            return result == null ? _placeholder : result;
        }
        
        public Sprite GetSprite<T>(T type) where T: Enum
        {
            var result = _icons.FirstOrDefault(s => s.name.Equals(type.ToString()));
            return result == null ? _placeholder : result;
        }
    }
}