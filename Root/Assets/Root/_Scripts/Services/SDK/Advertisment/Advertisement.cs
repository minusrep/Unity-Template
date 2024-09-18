using System;
using UnityEngine;

namespace Root.Services.SDK
{
    public class Advertisement : IAdvertisement
    {
        public event Action OnAdvOpenEvent;

        public event Action<int> OnAdvRewardedEvent;

        public event Action OnAdvCloseEvent;

        public virtual void ShowFullscreenAdv()
        {
            OnAdvOpenEvent?.Invoke();

            Debug.Log($"Unity: fullscreen adv");

            OnAdvCloseEvent?.Invoke();
        }

        public virtual void ShowRewardedAdv(int id = 0)
        {
            OnAdvOpenEvent?.Invoke();

            Debug.Log($"Unity: rewarded adv");

            OnAdvRewardedEvent?.Invoke(id);

            OnAdvCloseEvent.Invoke();
        }

        public void OnAdvOpen()
            => OnAdvOpenEvent?.Invoke();
        public void OnAdvRewarded(int id = 0)
            => OnAdvRewardedEvent?.Invoke(id);

        public void OnAdvClose()
            => OnAdvCloseEvent?.Invoke();
    }
}
