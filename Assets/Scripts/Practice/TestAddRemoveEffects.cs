using Practice.Effects;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using static Practice.Effects.EffectType;

namespace Practice
{
    public sealed class TestAddRemoveEffects : MonoBehaviour
    {
        private EffectSystem _effectSystem;

        [Inject]
        public void Construct(EffectSystem effectSystem)
        {
            _effectSystem = effectSystem;
        }
        
        [Button(ButtonSizes.Large, Icon = SdfIconType.ArrowUp)]
        public void TryCreateOrAddEnergy() 
            => _effectSystem.TryApplyOrCreateEffect(Energy);

        [Button(ButtonSizes.Large, Icon = SdfIconType.ArrowUp)]
        public void TryCreateOrAddAttack() 
            => _effectSystem.TryApplyOrCreateEffect(Attack);

        [Button(ButtonSizes.Large, Icon = SdfIconType.ArrowUp)]
        public void TryCreateOrAddMoney() 
            => _effectSystem.TryApplyOrCreateEffect(Money);

        [Button(ButtonSizes.Large, Icon = SdfIconType.Backspace,
            IconAlignment = IconAlignment.LeftOfText )]
        public void RemoveEnergy() 
            => _effectSystem.TryRemoveEffect(Energy);

        [Button(ButtonSizes.Large, Icon = SdfIconType.Backspace,
            IconAlignment = IconAlignment.LeftOfText )]
        public void RemoveAttack() 
            => _effectSystem.TryRemoveEffect(Attack);

        [Button(ButtonSizes.Large, Icon = SdfIconType.Backspace,
            IconAlignment = IconAlignment.LeftOfText )]
        public void RemoveMoney() 
            => _effectSystem.TryRemoveEffect(Money);
    }
}