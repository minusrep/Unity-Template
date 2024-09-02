using Root.Constants;
using Root.Core;
using Root.Services.SDK.Yandex;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Root.Services.SDK
{
    public class YandexStrategy : UnityStrategy
    {
        #region "Internal methods" 

        #region "Advertisement"
        [DllImport("__Internal")]
        private static extern void ShowFullScreenAdvExtern();

        [DllImport("__Internal")]
        private static extern void ShowRewardedAdvExtern(int id);
        #endregion

        #region "DataHandler"
        [DllImport("__Internal")]
        private static extern void SaveDataExtern(string data);

        [DllImport("__Internal")]
        private static extern void LoadDataExtern();
        #endregion

        #region "InDev"
        [DllImport("__Internal")]
        private static extern void RateGameExtern();

        [DllImport("__Internal")]
        private static extern void UpdateLeaderboardExtern(int value);

        [DllImport("__Internal")]
        private static extern string GetLanguageExtern();

        [DllImport("__Internal")]
        private static extern void GameReadyExtern();
        #endregion

        #endregion

        private ICreator _creator;

        private JSProvider _jsProvider;

        public override void Init(ILocator<IService> services)
        {
            _creator = services.Get<ICreator>();

            InitJSProvider(_creator);  
        }

        protected override void LoadData()
            => LoadDataExtern();

        protected override void SaveData()
            => SaveDataExtern(JsonUtility.ToJson(_dataHandler.Data));

        private void InitJSProvider(ICreator creator)
        {
            _jsProvider = new GameObject(ServicesConstants.JSProvider).AddComponent<JSProvider>();

            creator.Static(_jsProvider.gameObject);
        }
    }
}
