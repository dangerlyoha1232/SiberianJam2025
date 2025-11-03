using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Employee
{
    public class ManagerAgentMove : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent;
        public AgroZone AgroZone;

        [SerializeField] private float _pointReachThreshold;

        private float PatrolSpeed {get; set;}
        private float ChaseSpeed {get; set;}
        private List<GameObject> PatrolPath {get; set;}

        private int _currentPointIndex = 0;

        private GameObject _hero;
        private bool _isHeroNoticed;


        public void Construct(float patrolSpeed, float chaseSpeed, List<GameObject> patrolPath)
        {
            PatrolSpeed = patrolSpeed;
            ChaseSpeed = chaseSpeed;
            PatrolPath = patrolPath;
        }

        private void Start()
        {
            NavMeshAgent.updateRotation = false;
            NavMeshAgent.updateUpAxis = false;
            NavMeshAgent.speed = PatrolSpeed;

            AgroZone.HeroNoticed += HeroNoticed;

            if (PatrolPath != null)
                NavMeshAgent.SetDestination(PatrolPath[_currentPointIndex].transform.position);
        }

        private void HeroNoticed()
        {
            _isHeroNoticed = true;
            _hero = AgroZone.Hero;
        }

        private void Update()
        {
            if (PatrolPath.Count == 0)
                return;
            
            if (_isHeroNoticed)
            {
                NavMeshAgent.SetDestination(_hero.transform.position);
                NavMeshAgent.speed = ChaseSpeed;
            }
            else if (!NavMeshAgent.pathPending && NavMeshAgent.remainingDistance < _pointReachThreshold)
            {
                MoveToNextPoint();
            }
         
        }
        
        private void MoveToNextPoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % PatrolPath.Count;
            NavMeshAgent.SetDestination(PatrolPath[_currentPointIndex].transform.position);
        }

        private void OnDestroy()
        {
            AgroZone.HeroNoticed -= HeroNoticed;
        }
    }
}