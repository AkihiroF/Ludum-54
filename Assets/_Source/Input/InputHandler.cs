using _Source.Player;
using UnityEngine.InputSystem;
using Zenject;

namespace _Source.Input
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
    }
}