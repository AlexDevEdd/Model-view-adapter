using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Practice
{
    public sealed class EffectProvider : MonoBehaviour
    {
        [SerializeField] private EffectView _attackView;
        [SerializeField] private EffectView _moneyView;
        [SerializeField] private EffectView _energy;

        public EffectView AttackView => _attackView;

        public EffectView MoneyView => _moneyView;

        public EffectView Energy => _energy;
    }
}

