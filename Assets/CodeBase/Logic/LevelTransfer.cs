using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Logic
{
    public class LevelTransfer : MonoBehaviour
    {
        public string LevelName;
        public TriggerObserver _trigger;
        
        private IGameStateMachine _stateMachine;
        
        private bool _isLevelCompleted;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
            EmployeeSpawner.OnAllRecruited += AllRecruited;
            
            
            _trigger.OnTriggerEnter += OnEnter;
        }

        private void AllRecruited() =>
            _isLevelCompleted = true;

        private void OnEnter(Collider2D obj)
        {
            if (_isLevelCompleted)
                _stateMachine.Enter<LoadLevelState, string>(LevelName);
        }

        private void OnDestroy()
        {
            _trigger.OnTriggerEnter -= OnEnter;
            EmployeeSpawner.OnAllRecruited -= AllRecruited;
        }
    }
}