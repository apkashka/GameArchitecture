using CodeBase.Infrastructure.AssetManager;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.UI.Service.Windows;
using UnityEngine;

namespace CodeBase.UI.Service
{
    public class UIFactory : IUIFactory
    {
        private const string RootPath = "UI/UIRoot";
        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        
        private Transform _uiRoot;

        public UIFactory(IAssets assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public void CreateShop()
        {
            var config = _staticData.ForWindow(WindowId.Shop);
            Object.Instantiate(config.prefab, _uiRoot);
        }

        public void CreateUIRoot()
        {
            _uiRoot = _assets.Instantiate(RootPath).transform;
        }
    }
}