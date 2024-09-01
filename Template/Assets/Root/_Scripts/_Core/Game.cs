using Root.Services;
using System.Collections;

namespace Root.Core
{
    public class Game : IGame
    {
        public static IGame Instance => _instance;
        
        private static Game _instance { get; set; }

        public ILocator<IService> ServiceLocator { get; private set; }

        public void Init(ILocator<IService> serviceLocator)
        {
            _instance = this;

            ServiceLocator = serviceLocator;
        }

        public IEnumerator Run()
        {
            var sceneLoader = ServiceLocator.Get<ISceneLoader>();

            yield return sceneLoader.LoadSceneAsync(SceneType.Game);
        }
    }
}
