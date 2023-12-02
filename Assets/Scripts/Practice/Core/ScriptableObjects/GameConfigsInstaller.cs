using UnityEngine;
using Zenject;

namespace Practice.Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameConfigsInstaller", menuName = "Installers/GameConfigsInstaller")]
    public class GameConfigsInstaller : ScriptableObjectInstaller<GameConfigsInstaller>
    {
       [SerializeField] private GameConfigs configs;
       
        public override void InstallBindings() 
            => Container.BindInterfacesAndSelfTo<GameConfigs>()
                .FromInstance(configs)
                .AsSingle();
    }
}