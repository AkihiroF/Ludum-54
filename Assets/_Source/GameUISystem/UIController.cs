using System;
using SoundSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

namespace GameUISystem
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup mainMenuPanel;
        [SerializeField] private CanvasGroup settingsPanel;
        [SerializeField] private CanvasGroup tutorialPanel;

        [SerializeField] private Button mainToSettingsButton;
        [SerializeField] private Button mainToTutorialButton;
        [SerializeField] private Button settingsToMainButton;
        
        [SerializeField] private Slider slider;

        [SerializeField] private AudioSource source;
        
        private const string SOUND_NAME = "Sound";

        private InputAction _tutorialAction;
        private ISceneTransitMenu _sceneTransit;
        private ISound _sound;
        
        [Inject]
        private void Construct(PlayerInput playerInput, ISceneTransitMenu sceneTransit, ISound sound)
        {
            _tutorialAction = playerInput.UIActions.Enter;
            _sceneTransit = sceneTransit;
            _sound = sound;
        }
        
        private void UnSubscribe(InputAction.CallbackContext obj)
        {
            _tutorialAction.performed -= _sceneTransit.OnTransit;
            _tutorialAction.performed -= UnSubscribe;
        }

        private void Awake()
        {
            mainToSettingsButton.onClick.AddListener(ShowSettingsPanel);
            mainToSettingsButton.onClick.AddListener(SoundPlay);
            mainToTutorialButton.onClick.AddListener(ShowTutorialPanel);
            mainToTutorialButton.onClick.AddListener(SoundPlay);
            settingsToMainButton.onClick.AddListener(ShowMainMenuPanel);
            settingsToMainButton.onClick.AddListener(SoundPlay);

            slider.value = PlayerPrefs.HasKey(SOUND_NAME) ? PlayerPrefs.GetFloat(SOUND_NAME) : 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            _tutorialAction.performed += UnSubscribe;
            _tutorialAction.performed += _sceneTransit.OnTransit;
        }

        private void ShowMainMenuPanel()
        {
            SetPanelActive(mainMenuPanel, true);
            SetPanelActive(settingsPanel, false);
            SetPanelActive(tutorialPanel, false);
        }

        private void ShowSettingsPanel()
        {
            SetPanelActive(mainMenuPanel, false);
            SetPanelActive(settingsPanel, true);
            SetPanelActive(tutorialPanel, false);
        }

        private void ShowTutorialPanel()
        {
            SetPanelActive(mainMenuPanel, false);
            SetPanelActive(settingsPanel, false);
            SetPanelActive(tutorialPanel, true);
            _tutorialAction.Enable();
        }

        private void SoundPlay()
            => _sound.Play(source);

        private void SetPanelActive(CanvasGroup panel, bool isActive)
        {
            panel.alpha = isActive ? 1 : 0;
            panel.blocksRaycasts = isActive;
            panel.interactable = isActive;
        }
    }
}