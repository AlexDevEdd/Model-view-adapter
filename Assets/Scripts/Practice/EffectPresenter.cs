using System;

namespace Practice
{
    public sealed class EffectPresenter : IDisposable
    {
        private readonly Effect _effect;
        private readonly EffectView _effectView;
        private readonly EffectStorage _effectStorage;

        public EffectPresenter(Effect effect, EffectView effectView, EffectStorage effectStorage)
        {
            _effect = effect;
            _effectView = effectView;
            _effectStorage = effectStorage;

            _effectView.SetView(_effect);
            _effectView.UpdateValue(effect.Value.CovertToString());
            
            _effect.OnValueChanged += OnValueChanged;
            _effectStorage.OnAdded += AddedEffect;
            _effectStorage.OnRemoved += RemovedEffect;
        }

        private void RemovedEffect(Effect certainEffect)
        {
            if (certainEffect == _effect) _effectView.gameObject.SetActive(false);
        }

        private void AddedEffect(Effect certainEffect)
        {
            if (certainEffect == _effect) _effectView.gameObject.SetActive(true);
        }

        private void OnValueChanged(float value) => _effectView.UpdateValue(value.CovertToString());

        void IDisposable.Dispose()
        {
            _effect.OnValueChanged -= OnValueChanged;
            _effectStorage.OnAdded -= AddedEffect;
            _effectStorage.OnRemoved -= RemovedEffect;
        }
    }
}