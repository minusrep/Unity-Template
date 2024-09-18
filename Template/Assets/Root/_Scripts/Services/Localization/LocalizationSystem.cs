using System.Collections;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Root.Services
{
    public class LocalizationSystem : ILocalization
    {
        public IEnumerator Init()
        {
            yield return LocalizationSettings.InitializationOperation;
        }
        public void SetLocale(LocaleIdentifier identifier)
        {
            var locale = LocalizationSettings.AvailableLocales.GetLocale(identifier);

            if (locale == null) return;

            LocalizationSettings.SelectedLocale = locale;
        }
    }
}
