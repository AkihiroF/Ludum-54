using System;
using GameUISystem;
using ObjectSystem;
using UnityEngine;

namespace TestPlayer
{
    public class Player : MonoBehaviour
    {
        public event Action LookOnItem;
        public event Action NotLookOnItem;
        
        [SerializeField] private Transform transformCamera;
        [SerializeField] private Transform hand;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed;
        [SerializeField] private LayerMask selectionTheInterior;
        [SerializeField] private LayerMask selectionTheKey;
        [SerializeField] private float distance;
        [SerializeField] private FixedJoint joint;

        [SerializeField] private GameUIView view;
        private GameUI _controller;

        private InteractionWithTheInterior _interactionWithTheInterior;
        private InteractionWithTheKey _interactionWithTheKey;
        private RaycastHit _hit;
        
        void Start()
        {
            _controller = new GameUI(view);
            LookOnItem += _controller.LookOnItem;
            NotLookOnItem += _controller.NotLookOnItem;
            
            _interactionWithTheInterior = new InteractionWithTheInterior(hand, joint);
            _interactionWithTheKey = new InteractionWithTheKey();
        }

        void Update()
        {
            BodyRotate();
            Eye();
            Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        
        private void BodyRotate()
        {
            Quaternion rotation = transform.rotation;
            transform.rotation = Quaternion.Euler(rotation.x, transformCamera.rotation.eulerAngles.y, rotation.z);
        }

        private void Move(float valueX, float valueZ) 
            => rb.velocity = (transform.right * valueX + transform.forward * valueZ) * speed;

        private void Eye()
        {
            if (Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, distance, selectionTheInterior)
                && !_interactionWithTheInterior.HaveItem
                && Input.GetKeyDown(KeyCode.F))
            {
                //LookOnItem?.Invoke();
                _interactionWithTheInterior.Selection(_hit.transform);
            }
            else if (Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, distance, selectionTheKey)
                     && Input.GetKeyDown(KeyCode.F))
            {
                //LookOnItem?.Invoke();
                _interactionWithTheKey.Selection(_hit.transform.gameObject);
            }
            else if (_interactionWithTheInterior.HaveItem
                     && Input.GetKeyDown(KeyCode.F))
            {
                _interactionWithTheInterior.Drop();
            }
            else if (Input.GetKey(KeyCode.Mouse0)
                     && _interactionWithTheInterior.HaveItem)
            {
                // TODO Rotate object AxisX
            }
            // else
            // {
            //     NotLookOnItem?.Invoke();
            // }
            if (Physics.Raycast(transformCamera.position, transformCamera.forward,  out _hit, distance, selectionTheInterior)
                && !_interactionWithTheInterior.HaveItem
                || Physics.Raycast(transformCamera.position, transformCamera.forward, out _hit, distance, selectionTheKey))
            {
                LookOnItem?.Invoke();
            }
            else
            {
                NotLookOnItem?.Invoke();
            }
        }
    }
}
