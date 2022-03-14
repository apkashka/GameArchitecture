using System;
using CodeBase.SimpleInput;

namespace CodeBase.Infrastructure.Services.UserInput
{
    internal class InputService : IInputService, IDisposable
    {
        public event Action ScreenTouched;

        public InputService()
        {
            TempInput.ScreenTouched += OnExternalInputTouched;
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