using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        GameObject CreateHud();
        
        GameObject ConstructEmployee(EmployeeType type, Transform parent);
        GameObject ConstructEmployee(EmployeeType type, Transform parent, List<GameObject> patrolPath);
    }
}