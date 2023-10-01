using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUISystem
{
    public class GameUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private GameObject hint;
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text text;

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
            image.DOColor(Color.red, TIME_FLASHING).OnComplete(() =>
            {
                image.DOColor(Color.white, TIME_FLASHING);
            });
            text.DOColor(Color.red, TIME_FLASHING).OnComplete(() =>
            {
                text.DOColor(Color.white, TIME_FLASHING);
            });
        }
    }
}