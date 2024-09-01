using System;
using UnityEngine;

namespace Root.Services.Audio
{
    public class Source : ISource
    {
        public event Action<bool> OnMuteChangeEvent;

        public bool Mute
        {
            get => _source.mute;

            set
            {
                _source.mute = value;

                OnMuteChangeEvent?.Invoke(value);
            }
        }

        private AudioSource _source;

        public void Init(Transform parent, string name)
        {
            _source = new GameObject(name).AddComponent<AudioSource>();

            _source.transform.parent = parent;
        }
    }
}
