using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Employee;
using CodeBase.Hero;
using CodeBase.Infrastructure.Services.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private IStaticDataService _staticDataService;
        
        public GameFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }
        
        public GameObject CreateHero(GameObject at)
        {
            GameObject prefab = Resources.Load<GameObject>("Hero/Hero");
            GameObject hero = GameObject.Instantiate(prefab, at.transform.position, Quaternion.identity);
            
            var movement = hero.GetComponent<HeroMovement>();
            movement.Construct(_staticDataService.GetHeroData().Speed);

            var laserAttack = hero.GetComponent<HeroLaserAttack>();
            laserAttack.Construct(_staticDataService.GetHeroData().ManaCapacity, _staticDataService.GetHeroData().ManaDrainPerSecond);
            
            return hero;
        }

        public GameObject CreateHud()
        {
            var prefab = Resources.Load<GameObject>("Hud/Hud");
            return GameObject.Instantiate(prefab);
        }

        public GameObject ConstructEmployee(EmployeeType type, Transform parent)
        {
            EmployeeData employeeData = _staticDataService.ForEmployee(type);
            GameObject employee = GameObject.Instantiate(employeeData.Prefab, parent.position, Quaternion.identity, parent);

            var recruitment = employee.GetComponent<EmployeeRecruitment>();
            recruitment.ManaToRecruit = employeeData.ManaToRecruit;
            
            return employee;
        }

        public GameObject ConstructEmployee(EmployeeType type, Transform parent, List<GameObject> patrolPath)
        {
            EmployeeData employeeData = _staticDataService.ForEmployee(type);
            GameObject employee = GameObject.Instantiate(employeeData.Prefab, parent.position, Quaternion.identity, parent);

            var managerAgentMove = employee.GetComponent<ManagerAgentMove>();
            managerAgentMove.Construct(employeeData.PatrolSpeed, employeeData.ChaseSpeed, patrolPath);
            
            return employee;
        }
    }
}