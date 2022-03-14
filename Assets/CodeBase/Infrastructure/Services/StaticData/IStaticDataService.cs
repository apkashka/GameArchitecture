using CodeBase.Data.StaticData;
using CodeBase.Data.StaticData.Windows;
using CodeBase.UI.Service.Windows;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadStaticData();
        UnitData GetUnitData(int id);
        WindowConfig ForWindow(WindowId shop);
    }
}