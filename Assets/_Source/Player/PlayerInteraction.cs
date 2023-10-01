using _Source.Events;
using _Source.Services;
using ObjectSystem;
using UnityEngine;

namespace _Source.Player
{
    public class PlayerInteraction : MonoBehaviour, IInteraction
    {
        [SerializeField] private Transform transformCamera;
        [SerializeField] private Transform hand;
        
        private RaycastHit _hit;
        private InteractionWithTheInterior _interactionWithTheInterior; 
        private InteractionWithTheKey _interactionWithTheKey;
        private float _distance;
        private LayerMask _selectionTheInterior;
        private LayerMask _selectionTheKey;

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
                || Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, _distance, _selectionTheKey))
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
            }
            else if (Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, _distance, _selectionTheKey))
            {
                _interactionWithTheKey.Selection(_hit.transform.gameObject);
            }
            else if (_interactionWithTheInterior.HaveItem)
            {
                _interactionWithTheInterior.Drop();
            }
        }

        public void ObjectRotate()
        {
            // if (Input.GetKey(KeyCode.Mouse0)
            //     && _interactionWithTheInterior.HaveItem)
            // {
            //     // TODO Rotate object AxisX
            // }
        }
    }
}