using Root._Services._Core;
using UnityEngine;

namespace Root._Services._GameBehavior
{
    public interface ICreator : IService
    {
        T Create<T>(T prefab) where T : MonoBehaviour;
    }
}
