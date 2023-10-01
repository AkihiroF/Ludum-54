using TMPro;
using UnityEngine;

namespace GameUISystem
{
    public class GameUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private GameObject hint;
        [SerializeField] private TMP_Text text;
        
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
    }
}