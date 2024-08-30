using System;
using System.Collections.Generic;

namespace Root._Core._Locator
{
    public abstract class Locator<T> : ILocator<T>
    {
        protected Dictionary<Type, T> _elements;

        public Locator()
        {
            _elements = new Dictionary<Type, T>();
        }

        public T Get<U>() where U : T
        {
            var key = typeof(U);

            if (!_elements.ContainsKey(key)) throw new KeyNotFoundException($"{key.Name} not founded");

            return _elements[key];
        }
    }
}
