using Events;
using ObjectSystem;
using Services;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour, IInteraction
    {
        [SerializeField] private Transform transformCamera;
        [SerializeField] private Transform hand;
        [SerializeField] private LayerMask selectionTheDoor;
        
        private RaycastHit _hit;
        private InteractionWithTheInterior _interactionWithTheInterior; 
        private InteractionWithTheKey _interactionWithTheKey;
        private float _distance;
        private LayerMask _selectionTheInterior;
        private LayerMask _selectionTheKey;

        private ISceneTransit _transit;

        [Inject]
        private void Construct(ISceneTransit transit)
        {
            _transit = transit;
        }

        public bool HoldObject 
            => _interactionWithTheInterior.HaveItem;

        private void Start()
        {
            _interactionWithTheInterior = new InteractionWithTheInterior(hand);
            _interactionWithTheKey = new InteractionWithTheKey();
        }

        private void Update()
        {
            Hint();
        }
        
        private void Hint()
        {
            if (Physics.Raycast(transformCamera.position, transformCamera.forward,  out _hit, _distance, _selectionTheInterior)
                && !_interactionWithTheInterior.HaveItem
                || Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, _distance, _selectionTheKey)
                || Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, _distance, selectionTheDoor))
            {
                Signals.Get<OnLookOnObject>().Dispatch();
            }
            else
            {
                Signals.Get<OnNotLookOnObject>().Dispatch();
            }
        }

        public void SetParameters(float distance, LayerMask selectionTheInterior, LayerMask selectionTheKey)
        {
            _distance = distance;
            _selectionTheInterior = selectionTheInterior;
            _selectionTheKey = selectionTheKey;
        }

        public void InteractionWithObjects()
        {
            if (Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, _distance, _selectionTheInterior)
                && !_interactionWithTheInterior.HaveItem)
            {
                _interactionWithTheInterior.Selection(_hit.transform);
                Signals.Get<OnUpdateGameState>().Dispatch();
            }
            else if (Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, _distance, _selectionTheKey))
            {
                _interactionWithTheKey.Selection(_hit.transform.gameObject);
                Signals.Get<OnUpdateGameState>().Dispatch();
            }
            else if (Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, _distance, selectionTheDoor))
            {
                _transit.OnStartTransit();
                Signals.Get<OnUpdateGameState>().Dispatch();
            }
            else if (_interactionWithTheInterior.HaveItem)
            {
                _interactionWithTheInterior.Drop();
                Signals.Get<OnUpdateGameState>().Dispatch();
            }
        }

        public void ObjectRotate(float angle)
        {
            _interactionWithTheInterior.RotateObject(angle);
        }
    }
}