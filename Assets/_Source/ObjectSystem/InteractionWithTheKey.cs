using Events;
using Services;
using UnityEngine;

namespace ObjectSystem
{
    public class InteractionWithTheKey
    {
        public void Selection(GameObject key)
        {
            key.SetActive(false);
            Signals.Get<OnTakingKey>().Dispatch();
        }
    }
}