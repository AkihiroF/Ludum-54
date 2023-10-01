using _Source.Events;
using _Source.Services;
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