using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data
{
    [CreateAssetMenu(fileName = "StaticData/DialogueSystem", menuName = "DialogueSystem")]
    public class DialogueData : ScriptableObject
    {
        public List<string> Lines;
        public float SpeedText;
    }
}