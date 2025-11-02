using CodeBase.Logic;

namespace CodeBase.Infrastructure.States
{
    public class RestartGameState : IPayloadedState<string>
    {
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        
        public RestartGameState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(string payload)
        {
            _sceneLoader.Load(payload, onLoaded: OnLoaded);
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<LoadLevelState, string>("SampleScene");
        }
    }
}