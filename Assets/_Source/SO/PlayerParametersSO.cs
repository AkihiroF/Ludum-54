using System;
using Player;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "Player Parameters", fileName = "Player Parameters")]
    public class PlayerParametersSo : ScriptableObject
    {
        [SerializeField] private StatePlayer BigPlayerParameters;
        
        [Space]
        [SerializeField] private StatePlayer MediumParameters;

        [Space]
        [SerializeField] private StatePlayer SmallParameters;

        public bool TryGetParameters(SizePlayer size, out StatePlayer statePlayer)
        {
            switch (size)
            {
                case SizePlayer.Big:
                    statePlayer = BigPlayerParameters;
                    return true;
                case SizePlayer.Medium:
                    statePlayer = MediumParameters;
                    return true;
                case SizePlayer.Small:
                    statePlayer = SmallParameters;
                    return true;
                default:
                    statePlayer = default(StatePlayer);
                    return false;
            }
        }
    }

    [Serializable]
    public struct StatePlayer
    {
        public float speed;
        public float scale;
        public float radiusInteractable;
        public LayerMask interactableInteriorLayers;
        public LayerMask interactableKeyLayers;
    }
}