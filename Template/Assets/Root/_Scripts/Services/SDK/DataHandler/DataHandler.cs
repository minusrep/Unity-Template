using System;
using System.Collections.Generic;
using UnityEngine;

namespace Root.Services.SDK
{
    public class DataHandler : IDataHandler
    {
        public bool IsInitialized => Data != null;

        public Data Data { get; private set; }

        private Dictionary<Type, IEntityData> _dataMap;

        private Action _save;

        public void Init(Action save = null) 
            => _save = save;

        public void InitData(string data) 
            => InitData(JsonUtility.FromJson<Data>(data));

        public void InitData(Data data)
        {
            Data = data != null ? data : new Data();

            _dataMap = new Dictionary<Type, IEntityData>()
            {
                {Data.PlayerData.GetType(), Data.PlayerData},
            };
        }

        public void Save()
            => _save.Invoke();

        public T GetData<T>() where T : IEntityData 
            => (T) _dataMap[typeof(T)];

    }
}
