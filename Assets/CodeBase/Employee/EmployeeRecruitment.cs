using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Employee
{
    public class EmployeeRecruitment : MonoBehaviour, ITakeMana
    {
        public float ManaToRecruit {get; set;}

        public bool IsRecruited;
        public event Action OnManaChanged;
        
        public event Action OnRecruited;

        public float RecruitProgress {get; set;}
        

        private void Start()
        {
            RecruitProgress = 0;
        }

        private void Update()
        {
            if (IsRecruited)
                return;
            
            if (RecruitProgress >= ManaToRecruit)
            {
                IsRecruited = true;
                OnRecruited?.Invoke();
            }
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