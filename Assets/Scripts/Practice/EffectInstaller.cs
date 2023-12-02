using Practice.ScriptableObjects;
using UnityEngine;
using Zenject;
using static Practice.EffectType;

namespace Practice
{
    public sealed class EffectInstaller : MonoInstaller
    {
        [SerializeField] private EffectViewProvider _effectProvider;
        [SerializeField] private EffectConfigsSO _effectConfigs;
        
        private EffectStorage _effectStorage;
        private EffectManager _effectManager;
        
        public override void InstallBindings()
        {
            BindEffectStorage();
            BindEffectFactory();
            BindEffectAdapters();
        }

        private void BindEffectStorage()
        {
            _effectStorage = new EffectStorage();
            Container.Bind<EffectStorage>().FromInstance(_effectStorage)
                .AsSingle()
                .NonLazy();
        }

        private void BindEffectFactory()
        {
            _effectManager = new EffectManager(_effectConfigs, _effectStorage,_effectProvider);
             Container.Bind<EffectManager>().FromInstance(_effectManager)
                .AsSingle()
                .NonLazy();
        }

        private void BindEffectAdapters()
        {
            EffectViewProvider effectViewProvider = FindObjectOfType<EffectViewProvider>();
            effectViewProvider.Init();
            foreach (EffectType type in effectViewProvider.GetEffectTypes())
            {
                BindEffectAdapter(type);
            }
        }

        private void BindEffectAdapter(EffectType effectType)
        {
            var effect = _effectManager.CreateEffect(effectType);
            Container.Bind<EffectPresenter>()
                .AsTransient()
                .WithArguments(effect, _effectProvider.GetEffectView(effectType),_effectStorage).NonLazy();
        }
    }
}