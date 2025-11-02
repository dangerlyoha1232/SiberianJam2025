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
    }
}