using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Practice
{
    public sealed class EffectViewProvider : MonoBehaviour
    {
        [SerializeField] private EffectView[] _effectViews;

        private Dictionary<EffectType, EffectView> _dictEffectViews = new ();

        public void Awake()
        {
            _dictEffectViews = _effectViews.ToDictionary(view => view.EffectType, view => view);
        }

        public EffectView GetEffectView(EffectType type) => _dictEffectViews[type];

        public IEnumerable<EffectType> GetEffectTypes() => _dictEffectViews.Keys.AsEnumerable();
    }
}

