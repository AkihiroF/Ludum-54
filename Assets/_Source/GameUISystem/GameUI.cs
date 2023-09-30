namespace GameUISystem
{
    public class GameUI
    {
        private readonly GameUIView _view;
        
        public GameUI(GameUIView view)
        {
            _view = view;
        }
        
        public void LookOnItem()
        {
            _view.HintEnable();
        }

        public void NotLookOnItem()
        {
            _view.HintDisable();
        }
        
        public void AddEvent()
        {
            // _continueButton.onClick.AddListener(Continue);
            // _settingsButton.onClick.AddListener(OpenSettings);
            // _backButton.onClick.AddListener(CloseSettings);
            // _exitButton.onClick.AddListener(Exit);
            //
            // Signals.Get<CloseEyeSignal>().AddListener(CloseEye);
            //
            // _view.OnOpenEye += EnablePlayerInput;
        }

        public void RemoveEvent()
        {
            // _continueButton.onClick.RemoveListener(Continue);
            // _settingsButton.onClick.RemoveListener(OpenSettings);
            // _backButton.onClick.RemoveListener(CloseSettings);
            // _exitButton.onClick.RemoveListener(Exit);
            //
            // Signals.Get<CloseEyeSignal>().RemoveListener(CloseEye);
            //
            // _view.OnOpenEye -= EnablePlayerInput;
        }
    }
}