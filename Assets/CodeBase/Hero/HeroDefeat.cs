using System.Collections;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroDefeat : MonoBehaviour, IHeroDefeat
    {
        public HeroMovement _heroMovement;
        public HeroLaserAttack _heroLaser;
        
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
        }
        
        public void Defeat()
        {
            DisableHero();
            StartCoroutine(HeroDefeatRoutine());
        }

        private void DisableHero()
        {
            _heroMovement.enabled = false;
            _heroLaser.enabled = false;
        }

        private IEnumerator HeroDefeatRoutine()
        {
            Debug.Log("You lose");
            yield return new WaitForSeconds(5);
            _stateMachine.Enter<RestartGameState, string>("Initial");
        }
    }
}
