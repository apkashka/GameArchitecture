using CodeBase.Infrastructure.AssetManager;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.LocalProgress;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Infrastructure.Services.UserInput;
using CodeBase.UI.Service;
using CodeBase.UI.Service.Windows;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private static AllServices _services;
        private const string Initial = "Initial";

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services )
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;;
            
            RegisterServices();
        }
        
        private static void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<LocalDataService>(new LocalDataService());
            //почему именно нужен интерфес???

            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>()));

            var staticData = new StaticDataService();
            staticData.LoadStaticData();
            _services.RegisterSingle<IStaticDataService>(staticData);
            
            _services.RegisterSingle<IUIFactory>(new UIFactory( _services.Single<IAssets>(), staticData));
            _services.RegisterSingle<IWindowService>(new WindowService(_services.Single<IUIFactory>()));
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadProgress);
        }

        private void EnterLoadProgress()
        {
            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }
    }
}