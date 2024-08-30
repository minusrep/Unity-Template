using Root._Services._SceneLoader;
using System.Collections;
using UnityEngine;

namespace Root._Core
{
    public class Bootstrap : MonoBehaviour
    {
        private static Bootstrap _instance;

        private SceneLoader _sceneLoader;

        private Game _game;

        private IEnumerator Start()
            => Init();


        private IEnumerator Init()
        {
            if (_instance != null)
            {
                Destroy(_instance);

                yield break;
            }

            _instance = this;

            _sceneLoader = new SceneLoader();

            _sceneLoader.LoadSceneAsync(SceneType.Bootstrap, InitGame);
        }

        private void InitGame()
        {
            _game = new Game();
        }
    }
}
