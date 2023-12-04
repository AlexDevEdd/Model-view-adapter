using UnityEngine;
using Zenject;

namespace Practice.Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameResourcesInstaller", menuName = "Installers/GameResourcesInstaller")]
    public class GameResourcesInstaller : ScriptableObjectInstaller<GameResourcesInstaller>
    {
        [SerializeField] private GameResources _gameResources;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameResources>()
                .FromInstance(_gameResources)
                .AsSingle()
                .NonLazy();
        }
    }
}