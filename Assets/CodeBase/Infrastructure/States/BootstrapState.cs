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
            //AllServices.Container
        }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>(NextScene);
    }
}