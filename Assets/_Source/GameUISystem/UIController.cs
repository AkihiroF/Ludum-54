using ObjectSystem;
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

        private InputAction _tutorialAction;
        
        [Inject]
        private void Construct(PlayerInput playerInput, ISceneTransitMenu sceneTransit)
        {
            _tutorialAction = playerInput.UIActions.Enter;
            _tutorialAction.performed += sceneTransit.OnTransit;
        }

        private void Awake()
        {
            mainToSettingsButton.onClick.AddListener(ShowSettingsPanel);
            mainToTutorialButton.onClick.AddListener(ShowTutorialPanel);
            settingsToMainButton.onClick.AddListener(ShowMainMenuPanel);
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

        private void SetPanelActive(CanvasGroup panel, bool isActive)
        {
            panel.alpha = isActive ? 1 : 0;
            panel.blocksRaycasts = isActive;
            panel.interactable = isActive;
        }
    }
}