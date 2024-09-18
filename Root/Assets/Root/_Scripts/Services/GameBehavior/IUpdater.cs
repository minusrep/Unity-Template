using System;

namespace Root.Services
{
    public interface IUpdater : IService
    {
        event Action OnUpdate;
    }
}
