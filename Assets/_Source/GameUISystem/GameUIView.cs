using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUISystem
{
    public class GameUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private GameObject hint;
        [SerializeField] private Image imageKey;
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image imagePlayerSize;
        
        private const float TIME_FLASHING = 0.5f;
        
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