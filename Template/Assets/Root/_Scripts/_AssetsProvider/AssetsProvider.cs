using UnityEngine;

namespace Root
{
    public static class AssetsProvider 
    {
        public static T Load<T>(string path) where T : Object
        {
            var founded = Resources.Load<T>(path);

            if (founded == null) LogEmpty(path);

            return founded;
        }

        public static T[] LoadAll<T>(string path) where T : Object
        {
            var founded = Resources.LoadAll<T>(path);

            if (founded == null) LogEmpty(path);

            return founded;
        }


        private static void LogEmpty(string path)
        {
            Debug.Log($"{path} not found");
        }
    }
}
