using UnityEngine.InputSystem;

namespace _Source.Player
{
    public interface IMovable
    {
        public void SetInputAction(InputAction action);
        public void SwitchParametersMoving(float speed);
    }
}