using GameUISystem;
using SoundSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private UIController uiController;
        [SerializeField] private SceneTransitMenu sceneTransition;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
            Container.Bind<ISceneTransitMenu>().To<SceneTransitMenu>().FromInstance(sceneTransition);
            Container.Bind<UIController>().FromInstance(uiController);
            Container.Bind<ISound>().To<Sound>().AsSingle().NonLazy();
        }
    }
}