using System;
using CodeBase.SimpleInput;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.UserInput
{
    internal class InputService : IInputService, IDisposable
    {
        public event Action ScreenTouched;
        public InputService()
        {
            TempInput.ScreenTouched += OnExternalInputTouched;
            Debug.Log("InputService Bind");
        }

        private void OnExternalInputTouched()
        {
            ScreenTouched?.Invoke();
        }

        public void Dispose()
        {
            TempInput.ScreenTouched -= OnExternalInputTouched;
        }
    }
}