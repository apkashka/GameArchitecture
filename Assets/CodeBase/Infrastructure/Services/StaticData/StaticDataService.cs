using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodeBase.Data.StaticData;
using CodeBase.Data.StaticData.Windows;
using CodeBase.UI.Service.Windows;
using Newtonsoft.Json;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WindowsPath = "StaticData/WindowStaticData";

        private Dictionary<int, UnitData> _units;
        private Dictionary<WindowId, WindowConfig> _windowConfigs;
        private static string UnitsDataPath => Path.Combine(Application.dataPath, "data.json");

        public void LoadStaticData()
        {
            if (!File.Exists(UnitsDataPath))
            {
                Debug.LogError($"No file found: {UnitsDataPath}");
                return;
            }
            
            var fileContent = File.ReadAllText(UnitsDataPath);
            var units = JsonConvert.DeserializeObject<List<UnitData>>(fileContent);
            
            _units = units.ToDictionary(x => x.ID, x => x);
            
            _windowConfigs = Resources.Load<WindowStaticData>(WindowsPath).configs
                .ToDictionary(x => x.windowId, x => x);
        }

        public UnitData GetUnitData(int id)
        {
            if (_units.TryGetValue(id, out var unitData))
            {
                return unitData;
            }
            Debug.LogError($"No unit with {id} found");
            return null;
        }

        public WindowConfig ForWindow(WindowId windowId)
        {
            if (_windowConfigs.TryGetValue(windowId, out var windowConfig))
            {
                return windowConfig;
            }
            Debug.LogError($"No window for {windowId} type found");
            return null;
        }
    }
}