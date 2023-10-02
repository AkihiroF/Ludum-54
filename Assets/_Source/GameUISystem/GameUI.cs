using Events;
using Services;
using UnityEngine.UI;
using Zenject;

namespace GameUISystem
{
    public class GameUI : IUIController
    {
        private readonly IUIView _view;
        private int _keyCount;
        
        [Inject]
        public GameUI(IUIView view)
        {
            _view = view;
        }
        
        private void LookOnItem()
        {
            _view.HintEnable();
        }

        private void NotLookOnItem()
        {
            _view.HintDisable();
        }

        private void KeyCount(int count, int maxCount)
        {
            _view.KeyCount(count.ToString(), maxCount.ToString());
        }

        private void RedFlashing()
        {
            _view.RedFlashing();
        }

        private void ChangePlayerSizeIcon(Image image)
        {
            _view.ChangePlayerSizeIcon(image);
        }
        
        public void SubscribeToEvents()
        {
            Signals.Get<OnLookOnObject>().AddListener(LookOnItem);
            Signals.Get<OnNotLookOnObject>().AddListener(NotLookOnItem);
            Signals.Get<OnChangeResource>().AddListener(KeyCount);
            Signals.Get<OnNotAllKey>().AddListener(RedFlashing);
            Signals.Get<OnChangePlayerSize>().AddListener(ChangePlayerSizeIcon);
        }

        public void UnSubscribeToEvents()
        {
            Signals.Get<OnLookOnObject>().RemoveListener(LookOnItem);
            Signals.Get<OnNotLookOnObject>().RemoveListener(NotLookOnItem);
            Signals.Get<OnChangeResource>().RemoveListener(KeyCount);
            Signals.Get<OnChangeResource>().RemoveListener(KeyCount);
            Signals.Get<OnNotAllKey>().RemoveListener(RedFlashing);
            Signals.Get<OnChangePlayerSize>().RemoveListener(ChangePlayerSizeIcon);
        }
    }
}