using Root.Services;
using System.Collections;

namespace Root.Core
{
    public class Game
    {
        public ILocator<IService> ServiceLocator { get; private set; }

        public void Init(ILocator<IService> serviceLocator)
        {
            ServiceLocator = serviceLocator;
        }

        public IEnumerator Run()
        {
            var sceneLoader = ServiceLocator.Get<ISceneLoader>();

            yield return sceneLoader.LoadSceneAsync(SceneType.Game);
        }
    }
}
