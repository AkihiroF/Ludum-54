using _Source.Player;
using UnityEngine.InputSystem;
using Zenject;

namespace _Source.Input
{
    public class InputHandler
    {
        private ISetterParameters _setterParameters;

        [Inject]
        private void Construct(ISetterParameters setterParameters)
        {
            _setterParameters = setterParameters;
        }
        

        public void InputUpScaling(InputAction.CallbackContext obj)
        {
            _setterParameters.UpSizeParameters();
        }

        public void InputDownScaling(InputAction.CallbackContext obj)
        {
           _setterParameters.DownSizeParameters();
        }
    }
}