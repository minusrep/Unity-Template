using System;

namespace Root.Services.Audio
{
    public interface ISource
    {
        event Action<bool> OnMuteChangeEvent;

        bool Mute { get; set; }

    }
}
