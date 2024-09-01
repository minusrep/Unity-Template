using Root.Constants;
using Root.Core;
using UnityEngine.UIElements;
using DG.Tweening;
using UnityEngine;

namespace Root.Services.UI.Elements.Windows
{
    public abstract class UIWindow : UIElement<VisualElement>
    {
        public virtual string Name { get; protected set; }

        protected UIDocument _document;

        protected IWindowManipulator _manipulator;

        protected ICreator _creator;

        protected VisualElement _content;
        
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

            _content = _root.Q<VisualElement>(UIConstants.Content);
        }

        public override void Show()
        {
            _content.transform.scale = UIConstants.WindowAppearFrom * Vector3.one;

            IsActive = true;

            var appearTween = DOTween.To(() => _content.transform.scale,
                                    x => _content.transform.scale = x,
                                    Vector3.one, UIConstants.WindowAppearTime);
        }
    }
}
