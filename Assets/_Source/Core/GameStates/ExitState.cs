using _Source.Input;
using GameUISystem;
using ResourceSystem;
using Zenject;

namespace _Source.Core.GameStates
{
    public class ExitState : IGameState
    {
        private readonly IUIController _uiController;
        private readonly IResource _key;
        private readonly InputHandler _inputHandler;
        private readonly PlayerInput _playerInput;

        [Inject]
        public ExitState(InputHandler inputHandler, PlayerInput input, IUIController uiController, IResource key)
        {
            _playerInput = input;
            _inputHandler = inputHandler;
            _uiController = uiController;
            _key = key;
        }
        
        public void OnEnter()
        {
            _uiController.UnSubscribeToEvents();
            _key.UnSubscribeToEvents();
            UnSubscribeToEvents();
        }

        public void OnExit()
        {
            
        }

        public void Update()
        {
            
        }
        
        private void UnSubscribeToEvents()
        {
            _playerInput.PlayerActions.ScalingUp.performed -= _inputHandler.InputUpScaling;
            _playerInput.PlayerActions.ScalingDown.performed -= _inputHandler.InputDownScaling;
            _playerInput.PlayerActions.Interaction.performed -= _inputHandler.Interaction;
        }
    }
}