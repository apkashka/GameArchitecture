using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManager
{
    public interface IAssets : IService
    {
        public GameObject Instantiate(string path);
    }
}