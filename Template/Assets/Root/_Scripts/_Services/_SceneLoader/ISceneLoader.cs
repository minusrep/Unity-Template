using Root._Core._Locator;
using Root._Services._Core;
using System;
using System.Collections;

namespace Root._Services._SceneLoader
{
    public interface ISceneLoader : IService
    {
        IEnumerator LoadSceneAsync(SceneType scene, Action callback = null);
    }
}
