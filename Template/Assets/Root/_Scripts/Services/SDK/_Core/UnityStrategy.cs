using Root.Constants;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Root.Services.SDK
{
    public class UnityStrategy : IStrategy
    {
        public IDataHandler DataHandler => _dataHandler;

        public IAdvertisement Advertisement => _advertisement;
        
        private DataHandler _dataHandler;

        private Advertisement _advertisement;

        public IEnumerator Init() 
        {
            InitAdvertisement();

            _dataHandler = new DataHandler();

            LoadData();

            yield return new WaitUntil(() => _dataHandler.IsInitialized);
        }

        protected virtual void InitAdvertisement() 
            => _advertisement = new Advertisement();

        protected virtual void LoadData()
        {
            var data = File.Exists(AssetsConstants.SavePath) ? JsonUtility.FromJson<Data>(File.ReadAllText(AssetsConstants.SavePath)) : new Data();

            _dataHandler.Init(data, SaveData);
        }

        protected virtual void SaveData() 
            => File.WriteAllText(AssetsConstants.SavePath, JsonUtility.ToJson(_dataHandler.Data));
    }
}
