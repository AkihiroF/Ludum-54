using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class PlayerScalerComponent : MonoBehaviour
    {
        [SerializeField] private Transform objectScaling;
        [SerializeField] private float timeScaling;
        
        public void SetObjectScale(float scale)
        {
            objectScaling.DOScale(new Vector3(scale, scale, scale), timeScaling);
        }
    }
}