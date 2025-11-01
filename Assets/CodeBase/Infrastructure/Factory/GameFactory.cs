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
        
        public void CreateHero(GameObject at)
        {
            GameObject prefab = Resources.Load<GameObject>("Hero/Hero");
            GameObject hero = GameObject.Instantiate(prefab, at.transform.position, Quaternion.identity);
            
            var movement = hero.GetComponent<HeroMovement>();
            movement.Speed = _staticDataService.GetHeroData().Speed;
        }

        public void CreateHud()
        {
            var prefab = Resources.Load("Hud/Hud");
            GameObject.Instantiate(prefab);
        }
    }
}