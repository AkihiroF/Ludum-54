using DG.Tweening;
using SoundSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace GameUISystem
{
    public class GameUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private GameObject hint;
        [FormerlySerializedAs("image")] [SerializeField] private Image imageKey;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image imagePlayerSize;
        [SerializeField] private AudioSource source;

        private ISound _sound;

        private const float TIME_FLASHING = 0.5f;

        [Inject]
        private void Construct(ISound sound)
        {
            _sound = sound;
        }
        
        public void HintEnable()
        {
            hint.SetActive(true);
        }

        public void HintDisable()
        {
            hint.SetActive(false);
        }

        public void KeyCount(string count, string maxCount)
        {
            text.text = $"{count}/{maxCount}";
        }
        
        public void RedFlashing()
        {
            _sound.Play(source);
            imageKey.DOColor(Color.red, TIME_FLASHING).OnComplete(() =>
            {
                imageKey.DOColor(Color.white, TIME_FLASHING);
            });
            text.DOColor(Color.red, TIME_FLASHING).OnComplete(() =>
            {
                text.DOColor(Color.white, TIME_FLASHING);
            });
        }

        public void ChangePlayerSizeIcon(Sprite sprite)
        {
            imagePlayerSize.sprite = sprite;
        }
    }
}