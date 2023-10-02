using DG.Tweening;
using SoundSystem;
using UnityEngine;
using UnityEngine.InputSystem;
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
        private InputAction _interactionAction;

        [Inject]
        private void Construct(ISound sound, PlayerInput input)
        {
            _sound = sound;
            _interactionAction = input.PlayerActions.Interaction;
        }
        
        public void SetObjectScale(float scale)
        {
            var source = objectScaling.localScale.x > scale ? downSize : upSize;
            _interactionAction.Disable();
            
            _sound.Play(source);
            objectScaling.DOScale(new Vector3(scale, scale, scale), timeScaling).OnComplete(() =>
            {
                _sound.Stop(source);
                _interactionAction.Enable();
            });
        }
    }
}