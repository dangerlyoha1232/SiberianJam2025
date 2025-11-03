using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Logic;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string InitialScene = "Initial";
        private const string NextScene = "Level1";

        private GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        
        private AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }
        
        public void Enter()
        {
            WriteLog.StateLog(this);
            _sceneLoader.Load(InitialScene, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IGameStateMachine>(_stateMachine);
            RegisterStaticData();
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Container.Single<IStaticDataService>()));
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadEmployersData();
            _services.RegisterSingle(staticDataService);
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>(NextScene);
    }
}