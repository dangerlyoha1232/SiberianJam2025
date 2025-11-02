using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Employee
{
    public class EmployeeRecruitment : MonoBehaviour, ITakeMana
    {
        [SerializeField] private float _manaToRecruit;

        public bool IsRecruited;
        
        private float _recruitProgress;

        private void Start()
        {
            _recruitProgress = 0;
        }

        private void Update()
        {
            if (_recruitProgress >= _manaToRecruit)
                IsRecruited = true;
        }

        public void TakeMana(float amount)
        {
            if (IsRecruited)
                return;
            
            float actual = Mathf.Abs(amount);
            _recruitProgress += actual;
            Debug.Log(_recruitProgress);
        }
    }
}