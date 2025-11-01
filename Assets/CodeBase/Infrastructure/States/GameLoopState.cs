namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        public GameLoopState(GameStateMachine gameStateMachine)
        {
            
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