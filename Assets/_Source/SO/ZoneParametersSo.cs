using Player;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "ZoneParameters")]
    public class ZoneParametersSo : ScriptableObject
    {
        [SerializeField] private SizePlayer MaxAllowedSize;

        public SizePlayer GetMaxSize => MaxAllowedSize;
    }
}