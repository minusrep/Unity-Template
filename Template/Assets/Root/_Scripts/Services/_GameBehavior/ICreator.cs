using UnityEngine;

namespace Root.Services
{
    public interface ICreator : IService
    {
        T Create<T>(T prefab) where T : MonoBehaviour;

        void Static(GameObject prefab);
    }
}
