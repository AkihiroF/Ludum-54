using UnityEngine;

namespace ObjectSystem
{
    public class InteractionWithTheInterior
    {
        private const float DROP_FORCE = 1f;
        
        private readonly Transform _hand;

        private Transform _item;
        private Rigidbody _itemRb;
        private Collider _itemCollider;
        private bool _haveItem;

        public InteractionWithTheInterior(Transform hand)
        {
            _hand = hand;
        }
        
        public bool HaveItem => _haveItem;

        public void Selection(Transform transform)
        {
            _item = transform;
            _itemRb = _item.GetComponent<Rigidbody>();
            _itemCollider = _item.GetComponent<Collider>();
            
            _itemRb.isKinematic = true;
            _itemCollider.isTrigger = true;
            
            _item.parent = _hand;
            _item.localPosition = Vector3.zero;
            _item.localRotation = Quaternion.identity;
            _haveItem = true;
        }

        public void Drop()
        {
            _item.parent = null;
            _itemRb.isKinematic = false;
            _itemCollider.isTrigger = false;
            _itemRb.AddForce(_item.forward * DROP_FORCE, ForceMode.Impulse);
            ResetParameters();
        }

        public void RotateObject(float rotateAmount)
        {
            _item.transform.Rotate(rotateAmount, 0, 0);
        }

        private void ResetParameters()
        {
            _itemCollider = null;
            _itemRb = null;
            _haveItem = false;
        }
    }
}