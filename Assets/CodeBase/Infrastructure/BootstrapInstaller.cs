using CodeBase.Infrastructure.Services.UserInput;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().FromInstance(new InputService()).AsSingle();
        }
    }
}