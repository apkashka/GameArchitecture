using System;
using CodeBase.Data;
using UniRx;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.LocalProgress
{
    public class LocalDataService : IService, IDisposable
    {
        public IntReactiveProperty Level = new IntReactiveProperty();
        public IntReactiveProperty Money = new IntReactiveProperty();
        public BoolReactiveProperty SoundEnabled = new BoolReactiveProperty();
        
        public PlayerProgress PlayerProgress { get; set; }

        private readonly CompositeDisposable _lifetimeDisposable = new CompositeDisposable();
        
        public void LoadData()
        {
            PlayerProgress = GetSerializedFromPrefs<PlayerProgress>(nameof(PlayerProgress), new PlayerProgress());
            BindReactiveProperties();
        }

        public void ResetLocalData()
        {
            PlayerPrefs.DeleteAll();
        }

        public void SaveData()
        {
            PlayerPrefs.SetString(nameof(PlayerProgress), JsonUtility.ToJson(PlayerProgress));
            PlayerPrefs.Save();
        }
        
        private void BindReactiveProperties()
        {
            BindIntRP(Level, nameof(Level));
            BindIntRP(Money, nameof(Money));
            BindBoolRP(SoundEnabled, nameof(SoundEnabled), true);
        }

        private void BindIntRP(IntReactiveProperty reactiveProperty, string prefKey, int startValue = 0)
        {
            reactiveProperty.Value = PlayerPrefs.HasKey(prefKey) ? PlayerPrefs.GetInt(prefKey) : startValue;
            reactiveProperty.Subscribe(val =>
                PlayerPrefs.SetInt(prefKey, val)).AddTo(_lifetimeDisposable);
        }

        private void BindFloatRP(FloatReactiveProperty reactiveProperty, string prefKey, float startValue = 0)
        {
            reactiveProperty.Value = PlayerPrefs.HasKey(prefKey) ? PlayerPrefs.GetFloat(prefKey) : startValue;
            reactiveProperty.Subscribe(val =>
                PlayerPrefs.SetFloat(prefKey, val)).AddTo(_lifetimeDisposable);
        }

        private void BindBoolRP(BoolReactiveProperty reactiveProperty, string prefKey, bool startValue = false)
        {
            reactiveProperty.Value = PlayerPrefs.HasKey(prefKey) ? PlayerPrefs.GetInt(prefKey) == 0 : startValue;
            reactiveProperty.Subscribe(val =>
                PlayerPrefs.SetInt(prefKey, val ? 1 : 0)).AddTo(_lifetimeDisposable);
        }

        private void BindStringRP(StringReactiveProperty reactiveProperty, string prefKey, string startValue = "")
        {
            reactiveProperty.Value = PlayerPrefs.HasKey(prefKey) ? PlayerPrefs.GetString(prefKey) : startValue;
            reactiveProperty.Subscribe(val =>
                PlayerPrefs.SetString(prefKey, val)).AddTo(_lifetimeDisposable);
        }

        private T GetSerializedFromPrefs<T>(string prefKey, T startValue = default)
        {
            if (!PlayerPrefs.HasKey(prefKey))
            {
                return startValue;
            }

            var json = PlayerPrefs.GetString(prefKey);
            if (string.IsNullOrEmpty(json))
            {
                Debug.LogError($"Couldn't get correct data from: {prefKey} key");
                return startValue;
            }

            var deserializedData = JsonUtility.FromJson<T>(json);

            if (deserializedData == null)
            {
                Debug.LogError("Couldn't get correct data from: {prefKey} key");
                return default;
            }

            return deserializedData;
        }
        
        public void Dispose()
        {
            _lifetimeDisposable.Clear();
        }
    }
}