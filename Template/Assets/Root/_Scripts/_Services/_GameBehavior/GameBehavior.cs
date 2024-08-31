using System;
using UnityEngine;

namespace Root._Services._GameBehavior
{
    public class GameBehavior : MonoBehaviour, IUpdater, ICreator
    {
        public event Action OnUpdate;

        private void Update() 
            => OnUpdate?.Invoke();

        public T Create<T>(T prefab) where T : MonoBehaviour 
            => Instantiate(prefab);

        public void Static(GameObject prefab)
            => DontDestroyOnLoad(prefab);
    }
}
