using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using static Practice.EffectType;

namespace Practice
{
    public sealed class EffectProvider : MonoBehaviour
    {
        [SerializeField] private EffectView _attackView;
        [SerializeField] private EffectView _moneyView;
        [SerializeField] private EffectView _energyView;

        private Dictionary<EffectType, EffectView> _effectViews;

        private void Awake()
        {
            _effectViews = new Dictionary<EffectType, EffectView>
            {
                {Attack,_attackView},
                {Money,_moneyView},
                {Energy,_energyView}
            };
        }

        public EffectView GetEffectView(EffectType type) => _effectViews[type];
        
        public EffectView AttackView => _attackView;

        public EffectView MoneyView => _moneyView;

        public EffectView EnergyView => _energyView;
    }
}

