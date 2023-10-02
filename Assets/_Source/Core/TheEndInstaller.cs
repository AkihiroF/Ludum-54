using GameUISystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class TheEndInstaller : MonoInstaller
    {
        [SerializeField] private SceneTransitMenu sceneTransition;
        public override void InstallBindings()
        {
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
            Container.Bind<ISceneTransitMenu>().To<SceneTransitMenu>().FromInstance(sceneTransition);
            Container.Bind<TheEndComponent>().AsSingle().NonLazy();
        }
    }
}