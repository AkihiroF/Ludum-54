using System;
using Events;
using ObjectSystem;
using Services;
using UnityEngine;

namespace Player
{
    public class PlayerInteraction : MonoBehaviour, IInteraction
    {
        public event Action LookOnItem;
        public event Action NotLookOnItem;
        
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
                LookOnItem?.Invoke();
            }
            else
            {
                NotLookOnItem?.Invoke();
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
                //LookOnItem?.Invoke();
                _interactionWithTheInterior.Selection(_hit.transform);
                Signals.Get<OnUpdateGameState>().Dispatch();
            }
            else if (Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, _distance, _selectionTheKey))
            {
                //LookOnItem?.Invoke();
                _interactionWithTheKey.Selection(_hit.transform.gameObject);
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