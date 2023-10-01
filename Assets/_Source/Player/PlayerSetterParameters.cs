using SO;
using UnityEngine;

namespace Player
{
    public class PlayerSetterParameters : MonoBehaviour, ISetterParameters
    {
        [SerializeField] private SizePlayer starterSize;
        [SerializeField] private PlayerParametersSo parametersSo;
        [SerializeField] private PlayerMovementComponent movementComponent;
        [SerializeField] private PlayerScalerComponent scalerComponent;
        [SerializeField] private PlayerInteraction interaction;

        private SizePlayer _currentSize;
        private  ZoneParametersSo CurrentZone { get; set; }

        public void SetCurrentZone(ZoneParametersSo newZone)
        {
            CurrentZone = newZone;
        }

        private const SizePlayer MaxSize = SizePlayer.Big;
        private const SizePlayer MinSize = SizePlayer.Small;

        private void Start()
        {
            if (parametersSo == null || movementComponent == null || scalerComponent == null)
            {
                Debug.LogError("One or more components are not set!");
                return;
            }

            _currentSize = starterSize;
            SwitchParameters();
        }

        private void SwitchParameters()
        {
            if (parametersSo.TryGetParameters(_currentSize, out StatePlayer parameters))
            {
                SetParametersToPlayer(parameters);
            }
            else
            {
                Debug.LogError($"Parameters for size {_currentSize} not found");
            }
        }

        private void SetParametersToPlayer(StatePlayer parameters)
        {
            movementComponent.SwitchParametersMoving(parameters.speed);
            scalerComponent.SetObjectScale(parameters.scale);
            interaction.SetParameters(parameters.radiusInteractable, parameters.interactableInteriorLayers, parameters.interactableKeyLayers);
        }

        private void ChangeSize(int sizeDelta)
        {
            SizePlayer newSize = _currentSize + sizeDelta;

            if (CurrentZone != null && newSize > CurrentZone.GetMaxSize)
            {
                return;
            }

            if (newSize is <= MaxSize and >= MinSize)
            {
                _currentSize = newSize;
                SwitchParameters();
            }
        }

        public void UpSizeParameters()
        {
            ChangeSize(1);
        }

        public void DownSizeParameters()
        {
            ChangeSize(-1);
        }
    }
}