using Root._Constants;
using UnityEngine.UIElements;

namespace Root._UI._Elements._Windows._Core
{
    public abstract class UIWindow : UIElement<VisualElement>
    {
        public virtual string Name { get; protected set; }

        public UIWindow()
        {

        }

        private void ConstructRoot()
        {
            var prefab = AssetsProvider.Load<UIDocument>(AssetsConstants.UIWindowsPath + Name);

        }
    }
}
