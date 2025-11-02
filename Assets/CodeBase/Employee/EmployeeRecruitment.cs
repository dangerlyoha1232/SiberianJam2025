using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Employee
{
    public class EmployeeRecruitment : MonoBehaviour, ITakeMana
    {
        [SerializeField] private float _manaToRecruit;

        public bool IsRecruited;
        public event Action OnManaChanged;

        public float RecruitProgress {get; set;}
        public float ManaToRecruit => _manaToRecruit;

        private void Start()
        {
            RecruitProgress = 0;
        }

        private void Update()
        {
            if (RecruitProgress >= _manaToRecruit)
                IsRecruited = true;
        }

        public void TakeMana(float amount)
        {
            if (IsRecruited)
                return;
            
            float actual = Mathf.Abs(amount);
            RecruitProgress += actual;
            OnManaChanged?.Invoke();
            Debug.Log(RecruitProgress);
        }
    }
}