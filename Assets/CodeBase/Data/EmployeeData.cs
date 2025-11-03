using UnityEngine;

namespace CodeBase.Data
{
    [CreateAssetMenu(menuName = "StaticData/EmployeeData",  fileName = "EmployeeData")]
    public class EmployeeData : ScriptableObject
    {
        public EmployeeType Type;
        [Header("Employee Stats")]
        public float ManaToRecruit;
        
        [Header("Manager Stats")]
        public float PatrolSpeed;
        public float ChaseSpeed;
        
        [Header("Actor Prefab")]
        public GameObject Prefab;
    }
}