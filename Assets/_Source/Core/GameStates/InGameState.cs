using UnityEngine;
using Zenject;

namespace Core.GameStates
{
    public class InGameState : IGameState
    {
        private readonly IUIController _uiUIController;
        private readonly IResource _key;
        private readonly PlayerInput _input;

        private bool _isActiveRotating;

        [Inject]
        public InGameState(PlayerInput input, IResource key, IUIController uiController)
        {
            _input = input;
            _uiUIController = uiController;
            _key = key;
        }
        public void OnEnter()
        {
            _input.PlayerActions.Enable();
            _uiUIController.SubscribeToEvents();
            _key.SubscribeToEvents();
            _key.UpdateResourceCount();
            _input.PlayerActions.RotateItem.Disable();
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnExit()
        {
            
        }

        public void Update()
        {
            _isActiveRotating = !_isActiveRotating;
            if (_isActiveRotating)
            {
                _input.PlayerActions.RotateItem.Enable();
            }
            else
            {
                _input.PlayerActions.RotateItem.Disable();
            }
        }
    }
}