using System.Collections.Generic;
using Mods;

namespace Data
{
    public class StoreList
    {
        private static List<Store> stores = new List<Store>();

        
        static public void AddStore(Store store)
        {
            
            stores.Add(store);
        }

        static public List<Store> GetStores()
        {
            return stores;
        }
    }
}