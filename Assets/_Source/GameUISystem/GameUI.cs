using _Source.Events;
using _Source.Services;
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
        
        public void SubscribeToEvents()
        {
            Signals.Get<OnLookOnObject>().AddListener(LookOnItem);
            Signals.Get<OnNotLookOnObject>().AddListener(NotLookOnItem);
            Signals.Get<OnChangeResource>().AddListener(KeyCount);
        }

        public void UnSubscribeToEvents()
        {
            Signals.Get<OnLookOnObject>().RemoveListener(LookOnItem);
            Signals.Get<OnNotLookOnObject>().RemoveListener(NotLookOnItem);
            Signals.Get<OnChangeResource>().RemoveListener(KeyCount);
        }
    }
}