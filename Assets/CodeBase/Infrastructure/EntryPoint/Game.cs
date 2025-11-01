using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.Logic;

namespace CodeBase.Infrastructure.EntryPoint
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, AllServices services)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), services);
        }
    }
}