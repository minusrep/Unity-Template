using Root._Constants;
using Root._Core._Locator;
using Root._Services._Core;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Root._Services._SceneLoader
{
    public sealed class SceneLoader : Service, ISceneLoader
    {
        public event Action OnLoadEvent; 

        public event Action<float> OnLoadingEvent;

        public event Action OnLoadedEvent;

        public override void Init(ILocator<IService> services)
        {

        }

        public IEnumerator LoadSceneAsync(SceneType scene, bool delay = true, Action callback = null)
        {
            var index = (int) scene;

            var operation = SceneManager.LoadSceneAsync(index);

            OnLoadEvent?.Invoke();

            var timer = 0.01f;

            if (delay) timer = GameConstants.LoadingDelay;

            var current = timer;

            while (!operation.isDone || current > 0f)
            {
                var progress = delay ? (timer - current) / timer : operation.progress;

                current -= Time.deltaTime;

                OnLoadingEvent?.Invoke(progress);

                yield return null;
            }

            OnLoadedEvent?.Invoke();

            callback?.Invoke();
        }
    }
}
