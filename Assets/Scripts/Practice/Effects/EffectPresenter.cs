using System;
using System.Globalization;
using Practice.Core.Interfaces;

namespace Practice.Effects
{
    public sealed class EffectPresenter : IDisposable, IEffectPresenter
    {
        private readonly Effect _effect;
        private readonly EffectView _effectView;
        private readonly EffectStorage _effectStorage;
        public Effect Effect => _effect;
        public EffectView View => _effectView;

        public EffectPresenter(Effect effect, EffectView effectView, EffectStorage effectStorage)
        {
            _effect = effect;
            _effectView = effectView;
            _effectStorage = effectStorage;

            SetView(effect);

            _effect.OnValueChanged += OnValueChanged;
            _effectStorage.OnAdded += AddedEffect;
            _effectStorage.OnRemoved += RemovedEffect;
        }
        
        private void SetView(Effect effect)
        {
            _effectView.SetIcon(_effect.Icon);
            _effectView.SetBackColor(_effect.Color);
            _effectView.SetValue(CovertToString(effect.Value));
        }

        private void RemovedEffect(Effect certainEffect)
        {
            if (certainEffect == _effect)
                _effectView.gameObject.SetActive(false);
        }

        private void AddedEffect(Effect certainEffect)
        {
            if (certainEffect == _effect)
                _effectView.gameObject.SetActive(true);
        }

        private void OnValueChanged(float value)
            => _effectView.SetValue(CovertToString(value));

        private string CovertToString(float value)
            => $" +{value.ToString(CultureInfo.InvariantCulture)}%";

        public void Dispose()
        {
            _effect.OnValueChanged -= OnValueChanged;
            _effectStorage.OnAdded -= AddedEffect;
            _effectStorage.OnRemoved -= RemovedEffect;
        }
    }
}