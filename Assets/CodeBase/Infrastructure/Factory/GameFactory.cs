using CodeBase.Hero;
using CodeBase.Infrastructure.AssetManager;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }
        public void CreateUnit()
        {
           // = _assets.Instantiate("Hero").GetComponent<InputUser>();
            
           // Debug.Log("Unit created");
        }
    }
}