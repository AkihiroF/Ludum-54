using GameUISystem;
using ResourceSystem;
using UnityEngine;
using Zenject;

namespace _Source.Core.GameStates
{
    public class InGameState : IGameState
    {
        private readonly IUIController _uiUIController;
        private readonly IResource _key;
        private readonly PlayerInput _input;
        
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
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void OnExit()
        {
            
        }

        public void Update()
        {
            
        }
    }
}