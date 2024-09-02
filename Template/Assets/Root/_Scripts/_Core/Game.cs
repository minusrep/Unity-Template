using Root.Services;
using System.Collections;

namespace Root.Core
{
    public class Game
    {
        public ILocator<IService> ServiceLocator { get; private set; }

        private Session _actualSession;

        public void Init(ILocator<IService> serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        public IEnumerator Run()
        {
            _actualSession = new Session();

            yield return _actualSession.Run();
        }
    }
}
