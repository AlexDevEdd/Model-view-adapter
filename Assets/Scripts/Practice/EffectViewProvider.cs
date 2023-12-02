using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using static Practice.EffectType;

namespace Practice
{
    public sealed class EffectViewProvider : MonoBehaviour
    {
        [SerializeField] private EffectView[] _effectViews;

        private Dictionary<EffectType, EffectView> _dictEffectViews;

        private void Awake() => _dictEffectViews = _effectViews.ToDictionary(view => view.EffectType, view => view);

        public EffectView GetEffectView(EffectType type) => _dictEffectViews[type];
    }
}

