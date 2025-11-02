using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string SpawnPoint = "SpawnPoint";
        
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;
        private IGameFactory  _gameFactory;
        private IStaticDataService  _staticDataService;
        
        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = services.Single<IGameFactory>();
            _staticDataService = services.Single<IStaticDataService>();
        }
        
        public void Enter(string sceneName)
        {
            WriteLog.StateLog(this);
            _sceneLoader.Load(sceneName, onLoaded: OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            InitGameWorld();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitGameWorld()
        {
            var hero = _gameFactory.CreateHero(GameObject.FindGameObjectWithTag(SpawnPoint));
            
            CreateHud(hero);
        }

        private void CreateHud(GameObject hero)
        {
            var hud = _gameFactory.CreateHud();
            
            hud.GetComponent<HeroUI>().Construct(hero.GetComponent<IManaHolder>(), _staticDataService.GetHeroData().ManaCapacity);
        }
    }
}