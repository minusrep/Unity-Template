using Root.Services.UI.Elements;
using Root.Services.UI.Elements.Windows;
using UnityEngine.UIElements;

namespace Root.UI.Elements.Windows.Demo
{
    public class UIDemoControlsWindow : UIWindow
    {
        public override string Name => "DemoControls";

        private UIButton _nextButton;

        private UIButton _addButton;

        private UIButton _removeButton;

        private UIText _value;

        protected override void InitElements()
        {
            _nextButton = new UIButton(_root.Q<Button>("next-button"));

            _addButton = new UIButton(_root.Q<Button>("add-button"));

            _removeButton = new UIButton(_root.Q<Button>("remove-button"));
        }
    }
}
