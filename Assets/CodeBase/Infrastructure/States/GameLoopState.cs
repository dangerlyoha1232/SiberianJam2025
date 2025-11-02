namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private GameStateMachine _stateMachine;
        
        public GameLoopState(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        public void Enter()
        {
            WriteLog.StateLog(this);
        }

        public void Exit()
        {
            
        }
    }
}