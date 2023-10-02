using Player;
using Services;
using SO;
using UnityEngine;
using Zenject;

namespace ObjectSystem
{
    public class ZoneController : MonoBehaviour
    {
        [SerializeField] private ZoneParametersSo zoneParameters;
        [SerializeField] private LayerMask playerLayer;

        private ISetterParameters _playerSetter;
        [Inject]
        private void Construct(ISetterParameters setter)
        {
            _playerSetter = setter;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (playerLayer.CheckLayer(other.gameObject.layer))
            {
                _playerSetter.SetCurrentZone(zoneParameters);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (playerLayer.CheckLayer(other.gameObject.layer))
            {
                _playerSetter.SetCurrentZone(null);
            }
        }
    }
}