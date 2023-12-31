using Input;
using Player;
using Zenject;

namespace Core.GameStates
{
    public class BindingState : IGameState
    {
        private readonly InputHandler _inputHandler;
        private readonly PlayerInput _playerInput;
        private readonly IMovable _movable;

        [Inject]
        public BindingState(InputHandler inputHandler, PlayerInput playerInput, IMovable movable)
        {
            _inputHandler = inputHandler;
            _playerInput = playerInput;
            _movable = movable;
        }

        public void OnEnter()
        {
            SubscribeToEvents();
            _movable.SetInputAction(_playerInput.PlayerActions.Moving);
        }

        public void OnExit()
        {
            
        }

        public void Update()
        {
            
        }

        private void SubscribeToEvents()
        {
            _playerInput.PlayerActions.RotateItem.performed += _inputHandler.InputRotateItem;
            _playerInput.PlayerActions.ScalingUp.performed += _inputHandler.InputUpScaling;
            _playerInput.PlayerActions.ScalingDown.performed += _inputHandler.InputDownScaling;
            _playerInput.PlayerActions.Interaction.performed += _inputHandler.Interaction;
        }
    }
}