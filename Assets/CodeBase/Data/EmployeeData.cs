using UnityEngine;

namespace CodeBase.Data
{
    [CreateAssetMenu(menuName = "StaticData/EmployeeData",  fileName = "EmployeeData")]
    public class EmployeeData : ScriptableObject
    {
        public EmployeeType Type;
        public float ManaToRecruit;
        public float RecruitResist;
        public GameObject Prefab;
    }
}