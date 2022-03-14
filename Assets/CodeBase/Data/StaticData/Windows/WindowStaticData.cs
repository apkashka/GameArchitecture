using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Data.StaticData.Windows
{
    [CreateAssetMenu(menuName = "StaticData/WindowStaticData", fileName = "WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> configs;
    }
}