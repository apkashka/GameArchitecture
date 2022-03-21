using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.LocalProgress;
using CodeBase.Infrastructure.Services.UserInput;
using UnityEngine;
using Zenject;

namespace CodeBase.Hero
{
    public class InputUser : MonoBehaviour
    {
        private IInputService _inputService;
        private LocalDataService _data;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.ScreenTouched += SaveData;
        }
        private void Awake()
        {
            _data = AllServices.Container.Single<LocalDataService>();
        }


        private void OnDestroy()
        {
            _inputService.ScreenTouched -= SaveData;
        }

        private void SaveData()
        {
            _data.Level.Value++;
            _data.PlayerProgress.worldData.somePosition.X += 3;
            _data.SaveData();

            print($"Level is {_data.Level.Value}. SomePositionX is {_data.PlayerProgress.worldData.somePosition.X}");
        }
    }
}