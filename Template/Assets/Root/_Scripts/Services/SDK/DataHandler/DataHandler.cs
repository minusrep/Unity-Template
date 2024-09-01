using Root.Core;
using System;
using System.Collections.Generic;

namespace Root.Services
{
    public class DataHandler : IDataHandler, IServiceViewer
    {
        public Data Data { get; private set; }

        private Dictionary<Type, IEntityData> _dataMap;

        public void Init(ILocator<IService> services)
        {

        }

        public void InitData(Data data)
        {
            Data = data != null ? data : new Data()
            {
                PlayerData = new PlayerData(),
            };

            _dataMap = new Dictionary<Type, IEntityData>()
            {
                {Data.PlayerData.GetType(), Data.PlayerData},
            };
        }

        public T GetData<T>() where T : IEntityData 
            => (T) _dataMap[typeof(T)];
    }
}
