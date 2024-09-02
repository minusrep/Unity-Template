using Root.Services;
using Root.Services.Audio;
using Root.Services.SDK;
using System.Collections;

namespace Root.Core
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

            yield return InitSDK(serviceLocator);

            InitGameBehavior(serviceLocator);

            InitUserInterface(serviceLocator);

            InitAudioSystem(serviceLocator);

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
            var ui = new GUI();

            ui.Init(serviceLocator);

            serviceLocator.Register<IGUI>(ui);
        }

        private void InitAudioSystem(Locator<IService> serviceLocator)
        {
            var audio = new AudioSystem();

            audio.Init(serviceLocator);

            serviceLocator.Register<IAudio>(audio);
        }

        private IEnumerator InitSDK(Locator<IService> serviceLocator)
        {
            var sdk = new SDK();

            yield return sdk.Init();

            serviceLocator.Register<IAdvertisement>(sdk.Strategy.Advertisement);

            serviceLocator.Register<IDataHandler>(sdk.Strategy.DataHandler);
        }
    }
}
