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
        private const string NextScene = "SampleScene";

        private GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            
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
            AllServices.Container.RegisterSingle<IGameStateMachine>(_stateMachine);
            AllServices.Container.RegisterSingle<IStaticDataService>(new  StaticDataService());
            AllServices.Container.RegisterSingle<IInputService>(new InputService());
            AllServices.Container.RegisterSingle<IGameFactory>(new GameFactory(AllServices.Container.Single<IStaticDataService>()));
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>(NextScene);
    }
}