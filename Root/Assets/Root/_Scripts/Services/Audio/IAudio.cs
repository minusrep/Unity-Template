using Root.Services.Audio;
using UnityEngine;

namespace Root.Services
{
    public interface IAudio : IService
    {
        ISource Music { get; }

        ISource Sounds { get; }

        void PlayOneShot(AudioClip clip);
    }
}
