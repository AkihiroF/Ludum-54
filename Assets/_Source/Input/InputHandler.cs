using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input
{
    public class InputHandler
    {
        private ISetterParameters _setterParameters;
        private IInteraction _interaction;

        [Inject]
        private void Construct(ISetterParameters setterParameters, IInteraction interaction)
        {
            _setterParameters = setterParameters;
            _interaction = interaction;
        }
        

        public void InputUpScaling(InputAction.CallbackContext obj)
        {
            _setterParameters.UpSizeParameters();
        }

        public void InputDownScaling(InputAction.CallbackContext obj)
        {
           _setterParameters.DownSizeParameters();
        }

        public void Interaction(InputAction.CallbackContext obj)
        {
            _interaction.InteractionWithObjects();
        }

        public void InputRotateItem(InputAction.CallbackContext obj)
        {
            float rotateAmount = obj.ReadValue<Vector2>().y;
            _interaction.ObjectRotate(rotateAmount);
        }
    }
}