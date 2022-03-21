using CodeBase.Infrastructure.Factory;
using CodeBase.UI;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = loadingCurtain;
            _gameFactory = gameFactory;
        }
  
        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnSceneLoaded);
        }

        private void OnSceneLoaded()
        { 
            _gameFactory.CreateUnit();
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            _curtain.Hide();
        }
    }
}