using Practice.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Practice
{
    public sealed class EffectInstaller : MonoInstaller
    {
        [SerializeField] private EffectProvider _effectProvider;
        [SerializeField] private EffectConfigs _effectConfigs;
        
        private EffectStorage _effectStorage;
        private EffectFactory _effectFactory;
        
        public override void InstallBindings()
        {
            BindEffectStorage();
            BindEffectFactory();
            BindAttackAdapter();
            BindMoneyAdapter();
            BindEnergyAdapter();
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
            _effectFactory = new EffectFactory(_effectConfigs);
             Container.Bind<EffectFactory>().FromInstance(_effectFactory)
                .AsSingle()
                .NonLazy();
        } 
        
        private void BindAttackAdapter()
        {
            var effect = _effectFactory.Create(EffectType.Attack);
            _effectStorage.AddEffect(effect);
            Container.Bind<EffectPresenter>()
                .AsTransient()
                .WithArguments(effect, _effectProvider.AttackView)
                .NonLazy();
        }
        
        private void BindMoneyAdapter()
        {
            var effect = _effectFactory.Create(EffectType.Money);
            _effectStorage.AddEffect(effect);
            Container.Bind<EffectPresenter>()
                .AsTransient()
                .WithArguments(effect, _effectProvider.MoneyView)
                .NonLazy();
        }
        
        private void BindEnergyAdapter()
        {
            var effect = _effectFactory.Create(EffectType.Energy);
            _effectStorage.AddEffect(effect);
            Container.Bind<EffectPresenter>()
                .AsTransient()
                .WithArguments(effect, _effectProvider.Energy)
                .NonLazy();
        }
    }
}