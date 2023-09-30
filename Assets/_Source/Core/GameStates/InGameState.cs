using UnityEngine;
using Zenject;

namespace _Source.Core.GameStates
{
    public class InGameState : IGameState
    {
        [Inject]
        public InGameState(PlayerInput input)
        {
            _input = input;
        }
        private PlayerInput _input;
        public void OnEnter()
        {
            _input.PlayerActions.Enable();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnExit()
        {
            _input.PlayerActions.Disable();
        }

        public void Update()
        {
            
        }
    }
}