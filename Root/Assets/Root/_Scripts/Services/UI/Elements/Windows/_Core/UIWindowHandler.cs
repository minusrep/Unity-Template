using Root.Core;
using Root.Services.UI.Elements.Windows;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Root.Services.UI
{
    public abstract class UIWindowHandler : IWindowManipulator, IServiceUser
    {
        protected ILocator<IService> _services;

        private List<UIWindow> _windows;

        private UIWindow _actual;

        private UIWindow _previous;

        public UIWindowHandler()
        {
            _windows = new List<UIWindow>();
        }

        public virtual void Init(ILocator<IService> services) 
            => _services = services;

        public void OpenWindow<T>() where T : UIWindow
        {
            Clear();

            var founded = _windows.First(a => a is T);

            if (founded == null) throw new KeyNotFoundException($"{typeof(T)} not found");

            _previous = _actual;

            _actual = founded;

            _actual.Show();
        }

        public void PreviousWindow()
        {
            Clear();

            if (_previous == null) throw new ArgumentNullException("Previous window is empty");

            var last = _actual;

            _actual = _previous;

            _previous = last;

            _actual.Show();
        }

        protected void Clear()
            => _windows.ForEach(a => a.Hide());

        protected void AddWindow<T>() where T : UIWindow, new()
        {
            var window = new T();

            window.Init(_services, this);

            _windows.Add(window);
        }
    }
}
