using System;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Employee;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Logic
{
    public class EmployeeSpawner : MonoBehaviour
    {
        public static List<EmployeeRecruitment> Employees = new List<EmployeeRecruitment>();
        public static event Action OnAllRecruited;
        
        public EmployeeType EmployeeType;
        
        public List<GameObject> ManagerPath;
        
        private IGameFactory  _factory;
        
        private EmployeeRecruitment _defaultEmployee;

        private void Awake()
        {
            _factory = AllServices.Container.Single<IGameFactory>();
        }

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            if (EmployeeType == EmployeeType.DefaultEmployee)
            {
                GameObject employee = _factory.ConstructEmployee(EmployeeType, transform);
                _defaultEmployee = employee.GetComponent<EmployeeRecruitment>();
                Employees.Add(_defaultEmployee);
                _defaultEmployee.OnRecruited += EmployeeRecruited;

            }
            else if (EmployeeType == EmployeeType.ManagerEmployee)
                _factory.ConstructEmployee(EmployeeType, transform, ManagerPath);
        }

        private void EmployeeRecruited()
        {
            _defaultEmployee.OnRecruited -= EmployeeRecruited;
            Employees.Remove(_defaultEmployee);
            if (Employees.Count == 0)
                OnAllRecruited?.Invoke();
        }
    }
}
