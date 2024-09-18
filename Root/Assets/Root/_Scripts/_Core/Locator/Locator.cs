using System;
using System.Collections.Generic;

namespace Root.Core
{
    public class Locator<T> : ILocator<T>
    {
        protected Dictionary<Type, T> _elements;

        public Locator()
        {
            _elements = new Dictionary<Type, T>();
        }

        public U Get<U>() where U : T 
        {
            var key = typeof(U);

            if (!_elements.ContainsKey(key)) throw new KeyNotFoundException($"{key.Name} not founded");

            return (U) _elements[key];
        }
        public virtual U Register<U>(U element) where U : T
        {
            var key = typeof(U);

            _elements[key] = element;

            return (U) _elements[key];
        }
    }
}
