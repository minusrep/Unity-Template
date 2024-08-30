using Root._Core._Locator;

namespace Root._Services._Core
{
    public class ServiceLocator : Locator<IService>
    {
        public T Register<T>() where T : Service, IService, new()
        {
            var service = new T();

            service.Init(this);

            var key = service.GetType();

            _elements.Add(key, service);

            return service;
        }
    }
}
