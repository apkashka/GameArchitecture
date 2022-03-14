using CodeBase.Infrastructure.Services;

namespace CodeBase.UI.Service
{
    public interface IUIFactory : IService 
    {
        void CreateShop();
        void CreateUIRoot();
    }
}