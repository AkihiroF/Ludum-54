using UnityEngine.InputSystem;
using Zenject;

namespace GameUISystem
{
    public class TheEndComponent
    {
        private PlayerInput _playerInput;
        private ISceneTransitMenu _sceneTransit;
        [Inject]
        private void Construct(PlayerInput playerInput, ISceneTransitMenu sceneTransit)
        {
            _playerInput = playerInput;
            _sceneTransit = sceneTransit;
            _playerInput.UIActions.Enter.performed += UnSubscribe;
            _playerInput.UIActions.Enter.performed += _sceneTransit.OnTransit;
            _playerInput.UIActions.Enable();
        }

        private void UnSubscribe(InputAction.CallbackContext obj)
        {
            _playerInput.UIActions.Enter.performed -= _sceneTransit.OnTransit;
            _playerInput.UIActions.Enter.performed -= UnSubscribe;
        }
        
    }
}