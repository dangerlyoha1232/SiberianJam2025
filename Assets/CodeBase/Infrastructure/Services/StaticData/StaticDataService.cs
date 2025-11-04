using System.Collections.Generic;
using System.Linq;
using CodeBase.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EmployeeType, EmployeeData> _employees;
        
        public HeroData GetHeroData() =>
            Resources.Load<HeroData>("HeroData/HeroData");

        public void LoadEmployersData()
        {
            _employees = Resources.LoadAll<EmployeeData>("EmployeeData")
                .ToDictionary(x => x.Type, x => x);
        }

        public EmployeeData ForEmployee(EmployeeType type) =>
            _employees.GetValueOrDefault(type);
    }
}