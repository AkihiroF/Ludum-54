using Events;
using Services;
using UnityEngine;
using Zenject;

namespace Core.GameStates
{
    public class InGameState : IGameState
    {
        private bool _isActiveRotating;
        [Inject]
        public InGameState(PlayerInput input)
        {
            _input = input;
        }
        private PlayerInput _input;
        public void OnEnter()
        {
            _input.PlayerActions.Enable();
            _input.PlayerActions.RotateItem.Disable();
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnExit()
        {
            _input.PlayerActions.Disable();
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