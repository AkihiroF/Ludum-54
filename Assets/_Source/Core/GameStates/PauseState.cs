using GameUISystem;
using UnityEngine;
using Zenject;

namespace _Source.Core.GameStates
{
    public class PauseState : IGameState
    {
        private readonly PlayerInput _playerInput;
        private readonly IUIController _uiController;
        
        [Inject]
        public PauseState(PlayerInput playerInput, IUIController uiController)
        {
            _playerInput = playerInput;
            _uiController = uiController;
        }
        
        public void OnEnter()
        {
            _playerInput.PlayerActions.Disable();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _uiController.UnSubscribeToEvents();
        }

        public void OnExit()
        {
           
        }

        public void Update()
        {
            
        }
    }
}