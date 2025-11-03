using UnityEngine;

namespace CodeBase.Data
{
    [CreateAssetMenu(menuName = "StaticData/LevelData", fileName = "LevelData")]
    public class LevelData : ScriptableObject
    {
        public LevelType Type;
        
        public string LevelSceneName;
        
        public bool IsCompleted;
    }

    public enum LevelType
    {
        DefaultLevel,
        BossLevel
    }
}