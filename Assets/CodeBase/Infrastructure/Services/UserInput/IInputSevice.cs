using System;

namespace CodeBase.Infrastructure.Services.UserInput
{
    public interface IInputService : IService
    {
        event Action ScreenTouched;
    }
}