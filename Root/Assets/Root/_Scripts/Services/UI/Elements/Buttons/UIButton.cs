using System;
using UnityEngine.UIElements;

namespace Root.Services.UI.Elements
{
    public class UIButton : UIElement<Button>
    {
        public event Action OnClick;

        public UIButton(Button root) : base(root) 
        {
            root.clicked += OnClick;
        }
    }
}
