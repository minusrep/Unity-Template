using Root._Services._Core;
using System;

namespace Root._Services._GameBehavior
{
    public interface IUpdater : IService
    {
        event Action OnUpdate;
    }
}
