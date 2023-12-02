using Practice.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Practice
{
    public sealed class EffectInstaller : MonoInstaller
    {
        [SerializeField] private EffectConfigsSO _effectConfigs;
        [SerializeField] private EffectView[] _effectViews;
        private EffectCollection _effectStorage;
        private EffectManager _effectManager;
        
        public override void InstallBindings()
        {
            BindEffectStorage();
            BindEffectFactory();
            BindViewEffect();
        }

        private void BindEffectStorage()
        {
            _effectStorage = new EffectCollection();
            Container.Bind<EffectCollection>().FromInstance(_effectStorage)
                .AsSingle()
                .NonLazy();
        }

        private void BindEffectFactory()
        {
            _effectManager = new EffectManager(_effectConfigs, _effectStorage);
             Container.Bind<EffectManager>().FromInstance(_effectManager)
                .AsSingle()
                .NonLazy();
        }

        private void BindViewEffect()
        {
            foreach (EffectView view in _effectViews)
            {
                BindEffectAdapter(view.EffectType, view);
            }
        }

        private void BindEffectAdapter(EffectType effectType, EffectView effectView)
        {
            var effect = _effectManager.CreateEffect(effectType);
            Container.Bind<EffectPresenter>()
                .AsTransient()
                .WithArguments(effect, effectView,_effectStorage).NonLazy();
        }
    }
}