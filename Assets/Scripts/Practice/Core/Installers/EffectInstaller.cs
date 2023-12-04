using Practice.Effects;
using UnityEngine;
using Zenject;

namespace Practice.Core.Installers
{
    public sealed class EffectInstaller : MonoInstaller
    {
        [SerializeField] private Transform _viewRoot;
        [SerializeField] private Transform _viewParent;
        
        public override void InstallBindings()
        {
            BindEffectFactory();
            BindEffectSystem();
        }
        
        private void BindEffectFactory()
        {
            Container.Bind<EffectFactory>()
                .AsSingle()
                .WithArguments(_viewRoot, _viewParent)
                .NonLazy();
        }

        private void BindEffectSystem()
        {
            Container.Bind<EffectSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}