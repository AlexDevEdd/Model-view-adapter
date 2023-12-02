using Practice.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Practice
{
    public sealed class EffectInstaller : MonoInstaller
    {
        [SerializeField] private EffectConfigsSO _effectConfigs;
        [SerializeField] private EffectViewProvider _effectViewProvider;
        private EffectStorage _effectStorage;
        private EffectManager _effectManager;
        
        public override void InstallBindings()
        {
            BindEffectStorage();
            BindEffectFactory();
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
            _effectManager = new EffectManager(_effectConfigs, _effectStorage, _effectViewProvider);
             Container.Bind<EffectManager>().FromInstance(_effectManager)
                .AsSingle()
                .NonLazy();
        }
    }
}