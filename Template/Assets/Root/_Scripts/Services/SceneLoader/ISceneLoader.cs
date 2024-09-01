using System;
using System.Collections;

namespace Root.Services
{
    public interface ISceneLoader : IService
    {
        event Action OnLoadEvent;

        event Action<float> OnLoadingEvent;

        event Action OnLoadedEvent;

        IEnumerator LoadSceneAsync(SceneType scene, bool delay = true, Action callback = null);
    }
}
