using Root._Services._Core;
using Root._Services._SceneLoader;
using System.Collections;
using UnityEngine;

namespace Root._Core
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap _instance;

        private Game _game;

        private IEnumerator Start()
            => Init();


        private IEnumerator Init()
        {
            var singletonExists = !CreateSingleton();

            if (singletonExists) yield break;

            var serviceLocator = new ServiceLocator();

            var sceneLoader = serviceLocator.Register<ISceneLoader>(new SceneLoader());

            yield return sceneLoader.LoadSceneAsync(SceneType.Bootstrap);

            _game = new Game();

            _game.Init(serviceLocator);

            yield return _game.Run();
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
    }
}
