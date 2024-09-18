using UnityEngine.UIElements;

namespace Root.Services.UI.Elements
{
    public class UIText : UIElement<TextElement>
    { 
        public string Value
        {
            get => _root.text;

            set => _root.text = value;
        }

        public UIText(TextElement root) : base(root)
        {
            
        }
    }
}
