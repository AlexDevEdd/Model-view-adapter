using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using static Practice.ActionType;
using static Practice.EffectType;

namespace Practice
{
    public enum ActionType
    {
        ApplyEffect,
        RemoveEffect
    }
    
    public sealed class TestAddRemoveEffects : MonoBehaviour
    {
        private EffectManager _manager;

        [Inject]
        public void Construct(EffectManager manager)
        {
            _manager = manager;
        }

        private void Start() => ShowDemo();

        private void ShowDemo()
        {
            _manager.ApplyEffect(Energy);
            _manager.ApplyEffect(Attack);
            _manager.ApplyEffect(Money);
        }

        [Button]
        public void EffectOnEnergy(ActionType type = ApplyEffect)
        {
            if (type == ApplyEffect)
                _manager.ApplyEffect(Energy);
            else
                _manager.RemoveEffect(Energy);
        }

        [Button]
        public void EffectOnAttack(ActionType type = ApplyEffect)
        {
            if (type == ApplyEffect)
                _manager.ApplyEffect(Attack);
            else
                _manager.RemoveEffect(Attack);
        }

        [Button]
        public void EffectOnMoney(ActionType type = ApplyEffect)
        {
            if (type == ApplyEffect)
                _manager.ApplyEffect(Money);
            else
                _manager.RemoveEffect(Money);
        }
    }
}