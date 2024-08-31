using Root._Constants;
using Root._Core._Locator;
using Root._Services._Core;
using Root._Services._GameBehavior;
using UnityEngine.UIElements;

namespace Root._UI._Elements._Windows._Core
{
    public abstract class UIWindow : UIElement<VisualElement>
    {
        public virtual string Name { get; protected set; }

        protected UIDocument _document;

        protected IWindowManipulator _manipulator;

        protected ICreator _creator;
        
        public virtual void Init(ILocator<IService> services, IWindowManipulator manipulator)
        {
            _manipulator = manipulator;

            _creator = services.Get<ICreator>();

            ConstructRoot();

            InitElements();
        }

        protected abstract void InitElements();

        private void ConstructRoot()
        {
            var prefab = AssetsProvider.Load<UIDocument>(AssetsConstants.UIWindowsPath + Name);

            _document = _creator.Create(prefab);

            _root = _document.rootVisualElement;
        }
    }
}
