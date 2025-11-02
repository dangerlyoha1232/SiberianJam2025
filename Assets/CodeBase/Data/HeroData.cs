using UnityEngine;

namespace CodeBase.Data
{
    [CreateAssetMenu(menuName = "StaticData/HeroData", fileName = "HeroData")]
    public class HeroData : ScriptableObject
    {
        public float ManaCapacity;
        public float ManaDrainPerSecond;
        public float Speed;
    }
}
