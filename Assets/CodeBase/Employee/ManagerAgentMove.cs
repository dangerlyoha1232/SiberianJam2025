using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Employee
{
    public class ManagerAgentMove : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent;
        public AgroZone AgroZone;

        [SerializeField] private float _patrolSpeed;
        [SerializeField] private float _chaseSpeed;
        [SerializeField] private float _pointReachThreshold;
        [SerializeField] private List<GameObject> _patrolPath;

        private int _currentPointIndex = 0;

        private GameObject _hero;
        private bool _isHeroNoticed;


        private void Start()
        {
            NavMeshAgent.updateRotation = false;
            NavMeshAgent.updateUpAxis = false;
            NavMeshAgent.speed = _patrolSpeed;

            AgroZone.HeroNoticed += HeroNoticed;

            if (_patrolPath != null)
                NavMeshAgent.SetDestination(_patrolPath[_currentPointIndex].transform.position);
        }

        private void HeroNoticed()
        {
            _isHeroNoticed = true;
            _hero = AgroZone.Hero;
        }

        private void Update()
        {
            if (_patrolPath.Count == 0)
                return;
            
            if (_isHeroNoticed)
            {
                NavMeshAgent.SetDestination(_hero.transform.position);
            }
            else if (!NavMeshAgent.pathPending && NavMeshAgent.remainingDistance < _pointReachThreshold)
            {
                MoveToNextPoint();
            }
         
        }
        
        private void MoveToNextPoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPath.Count;
            NavMeshAgent.SetDestination(_patrolPath[_currentPointIndex].transform.position);
        }
    }
}