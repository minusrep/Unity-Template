using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Root._Services._SceneLoader
{
    public sealed class SceneLoader : ISceneLoader
    {
        public event Action OnSceneLoadingEvent;

        public event Action OnSceneLoadedEvent;

        public float Progress { get; private set; }

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
