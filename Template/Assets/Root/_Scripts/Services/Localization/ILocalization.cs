using UnityEngine.Localization;

namespace Root.Services
{
    public interface ILocalization : IService
    {
        void SetLocale(LocaleIdentifier locale);
    }
}
