using CodeBase.Hero;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Employee
{
    public class HeroDefeatZone : MonoBehaviour
    {
        public TriggerObserver TriggerObserver;

        private void Start()
        {
            TriggerObserver.OnTriggerEnter += DefeatHero;
        }

        private void DefeatHero(Collider2D obj)
        {
            obj.gameObject.TryGetComponent(out HeroDefeat heroDefeat);
            heroDefeat.Defeat();
        }
    }
}
