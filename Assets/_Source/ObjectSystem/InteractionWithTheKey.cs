using UnityEngine;

namespace ObjectSystem
{
    public class InteractionWithTheKey
    {
        public void Selection(GameObject key)
        {
            key.SetActive(false);
            // TODO signal about taking key
        }
    }
}