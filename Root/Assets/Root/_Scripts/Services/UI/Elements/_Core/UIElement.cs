using UnityEngine.UIElements;

namespace Root.Services.UI.Elements
{
    public class UIElement<T> where T : VisualElement
    {
        public bool IsActive 
        {
            get => _root.style.display == DisplayStyle.Flex;

            protected set => _root.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
        }

        protected T _root;

        public UIElement()
        {

        }

        public UIElement(T root)
        {
            _root = root;
        }
        
        public virtual void Show()
        {
            IsActive = true;
        }

        public virtual void Hide()
        {
            IsActive = false;
        }
    }
}
