using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ObjectSystem
{
    public class SceneTransition : MonoBehaviour,ISceneTransit
    {
        [SerializeField] private Image fadeScreen;
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private int nextSceneID;
        [SerializeField] private bool startWithFadeIn;

        private void Start()
        {
            if (startWithFadeIn)
            {
                fadeScreen.DOFade(0, fadeDuration).From(1);
            }
            else
            {
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 0);
            }
        }

        public void OnStartTransit()
        {
            fadeScreen.DOFade(1, fadeDuration).OnComplete(() =>
            {
                SceneManager.LoadScene(nextSceneID);
            });
        }
    }
}