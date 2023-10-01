using _Source.Events;
using _Source.Services;

namespace ResourceSystem
{
    public class Key : IResource
    {
        private readonly int _maxCount;
        
        private int _count;

        public Key(int maxCount)
        {
            _maxCount = maxCount;
        }

        private void AddKey()
        {
            _count++;
            UpdateResourceCount();
        }

        public void UpdateResourceCount()
        {
            Signals.Get<OnChangeResource>().Dispatch(_count, _maxCount);
        }

        public void SubscribeToEvents()
        {
            Signals.Get<OnTakingKey>().AddListener(AddKey);
        }

        public void UnSubscribeToEvents()
        {
            Signals.Get<OnTakingKey>().RemoveListener(AddKey);
        }
    }
}