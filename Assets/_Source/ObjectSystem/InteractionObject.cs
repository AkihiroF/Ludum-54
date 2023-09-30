using UnityEngine;

namespace ObjectSystem
{
    public class InteractionObject : MonoBehaviour
    {
        [SerializeField] private ObjectEnum objectEnum;

        public ObjectEnum GetObjectEnum() 
            => objectEnum;
    }
}