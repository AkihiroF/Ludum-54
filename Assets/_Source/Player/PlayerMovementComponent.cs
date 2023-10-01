using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovementComponent : MonoBehaviour, IMovable
    {
        [SerializeField] private Transform headCamera;
        private InputAction _movingAction;

        private float _currentSpeed;
        private Rigidbody _rb;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            if (_currentSpeed == 0)
            {
                Debug.LogWarning("Speed is not set. Please call SwitchParametersMoving to set the speed.");
            }
            if (_movingAction == null)
            {
                Debug.LogWarning("Moving action is not set. Please call SetInputAction to set the action.");
            }
        }

        public void SetInputAction(InputAction action)
        {
            _movingAction = action;
        }

        public void SwitchParametersMoving(float speed)
        {
            _currentSpeed = speed;
        }

        private void FixedUpdate()
        {
            HandleRotation();
            HandleMovement();
        }

        private void HandleRotation()
        {
            transform.rotation = Quaternion.Euler(0f, headCamera.rotation.eulerAngles.y, 0f);
        }

        private void HandleMovement()
        {
            if (_movingAction != null)
            {
                Vector3 moveInput = _movingAction.ReadValue<Vector3>();
                Vector3 direction = moveInput.normalized * _currentSpeed;
                direction.y = _rb.velocity.y;
                _rb.velocity = transform.TransformDirection(direction);
            }
        }
    }
}