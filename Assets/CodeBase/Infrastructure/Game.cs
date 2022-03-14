using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using CodeBase.UI;

namespace CodeBase.Infrastructure
{
    internal class Game
    {
        public readonly GameStateMachine StateMachine;
        
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container);
        }
        
    }
}