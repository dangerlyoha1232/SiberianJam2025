using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Logic
{
    public class RestoreManaZone : MonoBehaviour
    {
        public TriggerObserver _zoneObserver;

        private void Start()
        {
            _zoneObserver.OnTriggerEnter += OnHeroEnter;
            _zoneObserver.OnTriggerExit += OnHeroExit;
        }

        private void OnHeroEnter(Collider2D obj)
        {
            var hero = obj.gameObject.GetComponent<HeroLaserAttack>();
            hero.IsOnRestoreManaZone  = true;
            Debug.Log($"Hero entered {hero}");
        }

        private void OnHeroExit(Collider2D obj)
        {
            var hero = obj.gameObject.GetComponent<HeroLaserAttack>();
            hero.IsOnRestoreManaZone  = false;
            Debug.Log($"Hero exited {hero}");
        }
    }
}
