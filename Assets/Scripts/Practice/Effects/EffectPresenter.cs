using System.Globalization;
using Practice.Core.Interfaces;

namespace Practice.Effects
{
    public sealed class EffectPresenter : IEffectPresenter
    {
        private readonly Effect _effect;
        private readonly EffectView _effectView;

        public EffectPresenter(Effect effect, EffectView effectView)
        {
            _effect = effect;
            _effectView = effectView;
            
            SetView(effect);

            _effect.OnValueChanged += OnValueChanged;
        }

        public EffectView GetEffectView() 
            => _effectView;

        public Effect GetEffect() 
            => _effect;

        public void IncreaseEffectValue() 
            => _effect.IncreaseEffectValue();

        private void SetView(Effect effect)
        {
            _effectView.SetIcon(_effect.Icon);
            _effectView.SetBackColor(_effect.Color);
            _effectView.SetValue(CovertToString(effect.Value));
        }
        
        private void OnValueChanged(float value) 
            => _effectView.SetValue(CovertToString(value));

        private string CovertToString(float value) 
            => $" +{value.ToString(CultureInfo.InvariantCulture)}%";

        public void Dispose() 
            => _effect.OnValueChanged -= OnValueChanged;
    }
}