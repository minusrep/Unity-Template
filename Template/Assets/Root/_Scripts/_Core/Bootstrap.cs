using Root._Core._Locator;
using Root._Services._Core;
using Root._Services._GameBehavior;
using Root._Services._SceneLoader;
using Root._UI._Core;
using System.Collections;

namespace Root._Core
{
    public class Bootstrap : GameBehavior
    {
        private static Bootstrap _instance;

        private IEnumerator Start()
            => Init();

        private IEnumerator Init()
        {
            var singletonExists = !CreateSingleton();

            if (singletonExists) yield break;

            var serviceLocator = new Locator<IService>();

            var sceneLoader = InitSceneLoader(serviceLocator);

            yield return sceneLoader.LoadSceneAsync(SceneType.Bootstrap, false);

            InitGameBehavior(serviceLocator);

            InitUserInterface(serviceLocator);

            var game = new Game();

            game.Init(serviceLocator);

            yield return game.Run();
        }

        private bool CreateSingleton()
        {
            if (_instance != null)
            {
                Destroy(gameObject);

                return false;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);

            return true;
        }

        private ISceneLoader InitSceneLoader(Locator<IService> serviceLocator)
        {
            var sceneLoader = new SceneLoader();

            sceneLoader.Init(serviceLocator);

            serviceLocator.Register<ISceneLoader>(sceneLoader);

            return sceneLoader;
        }

        private void InitGameBehavior(Locator<IService> serviceLocator)
        {
            serviceLocator.Register<IUpdater>(this);

            serviceLocator.Register<ICreator>(this);
        }

        private void InitUserInterface(Locator<IService> serviceLocator)
        {
            var ui = new UserInterface();

            ui.Init(serviceLocator);

            serviceLocator.Register(ui);
        }
    }
}
