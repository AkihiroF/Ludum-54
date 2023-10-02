using Core;
using Core.GameStates;
using DG.Tweening;
using Events;
using Services;
using SoundSystem;
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
        [SerializeField] private AudioSource sourceCloseDoor;
        [SerializeField] private AudioSource sourceOpenDoor;

        private IGameStateMachine _state;
        private ISound _sound;
        private bool _canOpen;

        [Inject]
        private void Construct(IGameStateMachine state, ISound sound)
        {
            _state = state;
            _sound = sound;
        }

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
                _sound.Play(sourceCloseDoor);
                Signals.Get<OnNotAllKey>().Dispatch();
                return;
            }
            
            _sound.Play(sourceOpenDoor);
            fadeScreen.DOFade(1, fadeDuration).OnComplete(() =>
            {
                _state.SwitchGameState<ExitState>();
                Destroy(FindObjectOfType<SceneContext>().gameObject);
                SceneManager.LoadScene(nextSceneID);
            });
        }
    }
}