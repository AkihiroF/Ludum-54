using _Source.Core;
using _Source.Core.GameStates;
using _Source.Input;
using _Source.Player;
using GameUISystem;
using ResourceSystem;
using UnityEngine;
using Zenject;

namespace Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerMovementComponent movementComponent;
        [SerializeField] private PlayerSetterParameters setterParameters;
        [SerializeField] private PlayerInteraction interaction;
        [SerializeField] private GameUIView gameView;
        [SerializeField] private int maxCount;
        
        public override void InstallBindings()
        {
            Container.Bind<IMovable>().To<PlayerMovementComponent>().FromInstance(movementComponent);
            Container.Bind<ISetterParameters>().To<PlayerSetterParameters>().FromInstance(setterParameters);
            Container.Bind<IInteraction>().To<PlayerInteraction>().FromInstance(interaction);
            
            Container.Bind<PlayerInput>().AsSingle().NonLazy();
            Container.Bind<InputHandler>().AsSingle().NonLazy();
            Container.Bind<IGameState>().To<BindingState>().AsSingle().NonLazy();
            Container.Bind<IGameState>().To<InGameState>().AsSingle().NonLazy();
            Container.Bind<IGameState>().To<PauseState>().AsSingle().NonLazy();
            Container.Bind<IGameState>().To<ExitState>().AsSingle().NonLazy();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle().NonLazy();
            Container.Bind<Bootstrapper>().AsSingle();

            Container.Bind<IUIView>().To<GameUIView>().FromInstance(gameView);
            Container.Bind<IUIController>().To<GameUI>().AsSingle();

            Container.Bind<IResource>().To<Key>().AsSingle().WithArguments(maxCount);
        }
    }
}