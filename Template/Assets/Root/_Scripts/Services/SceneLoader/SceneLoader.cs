using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Root.Core;
using Root.Constants;

namespace Root.Services
{
    public sealed class SceneLoader : ISceneLoader
    {
        public event Action OnLoadEvent; 

        public event Action<float> OnLoadingEvent;

        public event Action OnLoadedEvent;

        public IEnumerator LoadSceneAsync(SceneType scene, bool delay = true, Action callback = null)
        {
            var index = (int) scene;

            var operation = SceneManager.LoadSceneAsync(index);

            OnLoadEvent?.Invoke();

            var timer = 0.01f;

            if (delay) timer = ServicesConstants.LoadingDelay;

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
