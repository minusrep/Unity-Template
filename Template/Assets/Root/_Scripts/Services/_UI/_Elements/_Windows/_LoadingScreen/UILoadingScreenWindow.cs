using Root.Constants;
using Root.Core;
using UnityEngine.UIElements;

namespace Root.Services.UI.Elements.Windows
{
    public sealed class UILoadingScreenWindow : UIWindow
    {
        public override string Name => "LoadingScreen";

        private UIProgressBar _progressBar;

        private ISceneLoader _sceneLoader;
    
        public override void Init(ILocator<IService> services, IWindowManipulator manipulator = null)
        {
            base.Init(services, manipulator);

            _creator.Static(_document.gameObject);

            _sceneLoader = services.Get<ISceneLoader>();

            ApplySubscribtions();
        }

        protected override void InitElements()
        {
            _progressBar = new UIProgressBar(_root.Q<VisualElement>(UIConstants.ProgressBar));
        }

        private void ApplySubscribtions()
        {
            _sceneLoader.OnLoadEvent += Show;

            _sceneLoader.OnLoadingEvent += (value) =>
            {
                _progressBar.Value = value;
            };

            _sceneLoader.OnLoadedEvent += Hide;
        }
    }
}
