using Root.Constants;
using Root.Core;
using UnityEngine;

namespace Root.Services.Audio
{
    public class AudioSystem : Service, IAudio
    {
        public ISource Music => _music;

        public ISource Sounds => _sounds;

        private ICreator _creator;

        private Source _music;

        private Source _sounds;

        private GameObject _root;

        public override void Init(ILocator<IService> services)
        {
            _creator = services.Get<ICreator>();

            _root = new GameObject(ServicesConstants.Audio);

            _creator.Static(_root);

            _music = CreateSource(ServicesConstants.Music);

            _sounds = CreateSource(ServicesConstants.Sounds);
        }

        private Source CreateSource(string name = "")
        {
            var source = new Source();

            source.Init(_root.transform, name);

            return source;
        }
    }
}
