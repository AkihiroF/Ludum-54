using DG.Tweening;
using SoundSystem;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerScalerComponent : MonoBehaviour
    {
        [SerializeField] private Transform objectScaling;
        [SerializeField] private float timeScaling;
        [SerializeField] private AudioSource upSize;
        [SerializeField] private AudioSource downSize;

        private ISound _sound;

        [Inject]
        private void Construct(ISound sound)
        {
            _sound = sound;
        }
        
        public void SetObjectScale(float scale)
        {
            var source = objectScaling.localScale.x > scale ? downSize : upSize;
            
            _sound.Play(source);
            objectScaling.DOScale(new Vector3(scale, scale, scale), timeScaling).OnComplete(() =>
            {
                _sound.Stop(source);
            });
        }
    }
}