using CodeBase.Infrastructure.Services.LocalProgress;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string SceneName = "Main";
        private readonly GameStateMachine _gameStateMachine;
        private readonly LocalDataService _data;

        public LoadProgressState(GameStateMachine gameStateMachine, LocalDataService data)
        {
            _gameStateMachine = gameStateMachine;
            _data = data;
        }
        
        public void Enter()
        {
            _data.LoadData();
            _gameStateMachine.Enter<LoadLevelState, string>(SceneName);
        }

        public void Exit()
        {
        }


    }
}