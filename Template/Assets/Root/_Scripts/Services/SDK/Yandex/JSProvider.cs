using UnityEngine;

namespace Root.Services.SDK.Yandex
{
    public class JSProvider : MonoBehaviour
    {
        private Advertisement _advertisement;

        private DataHandler _dataHandler;

        public void Init(Advertisement advertisement, DataHandler dataHandler)
        {
            _advertisement = advertisement;

            _dataHandler = dataHandler;
        }

        public void OnAdvOpen()
            => _advertisement.OnAdvOpen();
        
        public void OnAdvRewarded(int id = 0)
            => _advertisement.OnAdvRewarded(id);
        
        public void OnAdvClose()
            => _advertisement.OnAdvClose();

        public void InitData(string data)
            => _dataHandler.Init(); 
    }
}
