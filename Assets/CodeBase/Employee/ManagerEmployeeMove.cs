using System;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Employee
{
    public class ManagerEmployeeMove : MonoBehaviour
    {
        [SerializeField] private float _patrolSpeed;
        [SerializeField] private float _chaseSpeed;
        [SerializeField] private List<Vector2> _patrolPath;
        
        private float _actualSpeed;
        private List<Vector2> _actualPatrolPath;

        private void Start()
        {
            _actualSpeed = _patrolSpeed;
            _actualPatrolPath = _patrolPath;
        }

        private void Update()
        {
            for (int i = 0; i < _actualPatrolPath.Count; i++)
            {
                
            }
        }
    }
}
