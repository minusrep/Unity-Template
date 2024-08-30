using Root._Core._Locator;
using Root._Services._Core;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Root._Services._SceneLoader
{
    public sealed class SceneLoader : Service, ISceneLoader
    {
        public event Action OnSceneLoadingEvent;

        public event Action OnSceneLoadedEvent;

        public float Progress { get; private set; }

        public override void Init(ILocator<IService> services)
        {

        }
        
        public IEnumerator LoadSceneAsync(SceneType scene, Action callback = null)
        {
            var index = (int) scene;

            var operation = SceneManager.LoadSceneAsync(index);

            OnSceneLoadingEvent?.Invoke();

            while (!operation.isDone)
            {
                Progress = operation.progress;

                yield return null;
            }

            OnSceneLoadedEvent?.Invoke();

            callback?.Invoke();
        }
    }
}
