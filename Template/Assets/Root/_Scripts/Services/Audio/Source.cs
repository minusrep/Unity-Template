using System;
using UnityEngine;

namespace Root.Services.Audio
{
    public class Source : ISource
    {
        public event Action<bool> OnMuteChangeEvent;

        public bool Mute
        {
            get => AudioSource.mute;

            set
            {
                AudioSource.mute = value;

                OnMuteChangeEvent?.Invoke(value);
            }
        }

        public AudioSource AudioSource { get; private set; }

        public void Init(Transform parent, string name)
        {
            AudioSource = new GameObject(name).AddComponent<AudioSource>();

            AudioSource.transform.parent = parent;
        }
    }
}
