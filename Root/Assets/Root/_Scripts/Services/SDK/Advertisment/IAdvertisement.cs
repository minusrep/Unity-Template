using System;

namespace Root.Services
{
    public interface IAdvertisement : IService
    {
        event Action OnAdvOpenEvent;

        event Action<int> OnAdvRewardedEvent;

        event Action OnAdvCloseEvent;

        void ShowFullscreenAdv();

        void ShowRewardedAdv(int id);
    }
}
