using Root.Constants;
using Root.Core;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Root.Services.SDK
{
    public class UnityStrategy : IStrategy, IServiceUser
    {
        public IDataHandler DataHandler => _dataHandler;

        public IAdvertisement Advertisement => _advertisement;
        
        protected DataHandler _dataHandler;

        protected Advertisement _advertisement;

        public virtual void Init(ILocator<IService> services)
        {
            
        }

        public IEnumerator Init() 
        {
            InitAdvertisement();

            _dataHandler = new DataHandler();

            LoadData();

            yield return new WaitUntil(() => _dataHandler.IsInitialized);
        }

        protected virtual void LoadData()
        {
            var data = File.Exists(AssetsConstants.SavePath) ? JsonUtility.FromJson<Data>(File.ReadAllText(AssetsConstants.SavePath)) : new Data();

            _dataHandler.Init(SaveData);

            _dataHandler.InitData(data);
        }

        protected virtual void SaveData() 
            => File.WriteAllText(AssetsConstants.SavePath, JsonUtility.ToJson(_dataHandler.Data));

        private void InitAdvertisement()
            => _advertisement = new Advertisement();
    }
}
