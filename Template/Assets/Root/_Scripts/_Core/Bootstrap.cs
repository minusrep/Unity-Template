using Root._Services._Core;
using Root._Services._SceneLoader;
using System.Collections;
using UnityEngine;

namespace Root._Core
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap _instance;

        private IEnumerator Start()
            => Init();

        private IEnumerator Init()
        {
            var singletonExists = !CreateSingleton();

            if (singletonExists) yield break;

            var serviceLocator = new ServiceLocator();

           var sceneLoader = InitSceneLoader(serviceLocator);

            yield return sceneLoader.LoadSceneAsync(SceneType.Bootstrap);

            var game = new Game();

            game.Init(serviceLocator);

            yield return game.Run();
        }

        private bool CreateSingleton()
        {
            if (_instance != null)
            {
                Destroy(_instance);

                return false;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);

            return true;
        }

        private ISceneLoader InitSceneLoader(ServiceLocator serviceLocator)
        {
            var sceneLoader = new SceneLoader();

            sceneLoader.Init(serviceLocator);

            serviceLocator.Register<ISceneLoader>(sceneLoader);

            return sceneLoader;
        }
    }
}
