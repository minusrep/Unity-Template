using Root.Constants;
using Root.Core;
using System.Collections;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.UIElements;

namespace Root.Services
{
    public class LocalizationSystem : ILocalization
    {
        public IEnumerator Init()
        {
            yield return LocalizationSettings.InitializationOperation;
        }

        public void LocalizeUI(VisualElement root, string key)
        {

        }

        public void SetLocale(LocaleIdentifier identifier)
        {
            var locale = LocalizationSettings.AvailableLocales.GetLocale(identifier);

            if (locale == null) return;

            LocalizationSettings.SelectedLocale = locale;
        }
    }
}
