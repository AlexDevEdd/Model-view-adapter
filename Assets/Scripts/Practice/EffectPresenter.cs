using System.Globalization;

namespace Practice
{
    public sealed class EffectPresenter
    {
        private readonly Effect _effect;
        private readonly EffectView _effectView;

        public EffectPresenter(Effect effect, EffectView effectView)
        {
            _effect = effect;
            _effectView = effectView;
            _effect.OnValueChanged += OnValueChanged;
            _effectView.SetView(_effect);
            _effectView.UpdateValue(effect.Value.CovertToString());
        }

        private void OnValueChanged(float value) 
            => _effectView.UpdateValue(value.CovertToString());
    }
}