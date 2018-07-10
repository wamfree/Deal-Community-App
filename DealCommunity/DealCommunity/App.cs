using System;

namespace DealCommunity
{
    public class App
    {
        public static bool UseMockDataStore = false;
        public static string BackendUrl = "http://www.devtiberiuoprea.com";

        public static void Initialize()
        {
            if (UseMockDataStore)
                ServiceLocator.Instance.Register<IDataStore<Product>, MockDataStore>();
            else
                ServiceLocator.Instance.Register<IDataStore<Product>, CloudDataStore>();
        }
    }
}
