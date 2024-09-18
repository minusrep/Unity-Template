using System;

namespace Root.Services
{
    [Serializable]
    public class Data
    {
        public PlayerData PlayerData;

        public Data()
        {
            PlayerData = new PlayerData();
        }
    }
}
