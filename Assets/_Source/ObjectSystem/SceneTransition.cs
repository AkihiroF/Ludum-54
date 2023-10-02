using Core;
using Core.GameStates;
using DG.Tweening;
using Events;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace ObjectSystem
{
    public class SceneTransition : MonoBehaviour, ISceneTransit
    {
        [SerializeField] private Image fadeScreen;
        [SerializeField] private float fadeDuration = 1f;
        [SerializeField] private int nextSceneID;
        [SerializeField] private bool startWithFadeIn;
        [SerializeField] private AudioSource source;

        [Inject] private IGameStateMachine _state;

        private bool _canOpen;

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

        private void OnEnable()
        {
            Signals.Get<OnChangeResource>().AddListener(CheckResourceCount);
        }

        private void OnDisable()
        {
            Signals.Get<OnChangeResource>().RemoveListener(CheckResourceCount);
        }

        private void CheckResourceCount(int count, int maxCount)
        {
            if (count == maxCount)
            {
                _canOpen = true;
            }
        }

        public void OnStartTransit()
        {
            if (!_canOpen)
            {
                Signals.Get<OnNotAllKey>().Dispatch();
                return;
            }
            
            fadeScreen.DOFade(1, fadeDuration).OnComplete(() =>
            {
                _state.SwitchGameState<ExitState>();
                Destroy(FindObjectOfType<SceneContext>().gameObject);
                SceneManager.LoadScene(nextSceneID);
            });
        }
    }
}