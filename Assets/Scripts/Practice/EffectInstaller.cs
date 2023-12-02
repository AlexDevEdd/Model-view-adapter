using Practice.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Practice
{
    public sealed class EffectInstaller : MonoInstaller
    {
        [SerializeField] private EffectProvider _effectProvider;
        [SerializeField] private EffectConfigsSO _effectConfigs;
        
        private EffectStorage _effectStorage;
        private EffectManager _effectManager;
        
        public override void InstallBindings()
        {
            BindEffectStorage();
            BindEffectFactory();
            // BindAttackAdapter();
            // BindMoneyAdapter();
            // BindEnergyAdapter();
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
        
        // private void BindAttackAdapter()
        // {
        //     _effectManager.ApplyEffect(EffectType.Attack);
        //     
        //     var effect = _effectManager.ApplyEffect(EffectType.Attack);
        //     _effectStorage.AddEffect(effect);
        //     Container.Bind<EffectPresenter>()
        //         .AsTransient()
        //         .WithArguments(effect, _effectProvider.AttackView)
        //         .NonLazy();
        // }
        //
        // private void BindMoneyAdapter()
        // {
        //     var effect = _effectManager.ApplyEffect(EffectType.Money);
        //     _effectStorage.AddEffect(effect);
        //     Container.Bind<EffectPresenter>()
        //         .AsTransient()
        //         .WithArguments(effect, _effectProvider.MoneyView)
        //         .NonLazy();
        // }
        //
        // private void BindEnergyAdapter()
        // {
        //     var effect = _effectManager.ApplyEffect(EffectType.Energy);
        //     _effectStorage.AddEffect(effect);
        //     Container.Bind<EffectPresenter>()
        //         .AsTransient()
        //         .WithArguments(effect, _effectProvider.Energy)
        //         .NonLazy();
        // }
    }
}