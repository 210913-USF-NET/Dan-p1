using System.Collections.Generic;
using System;
namespace Mods
{
    public class Beer
    {
        public int Id 
        {get; set;}
        
        public string Name 
        {get; set;}

        public int Stock 
        {get; set;}

        public decimal Price 
        {get; set;}

        public Store store { get; set; }

        public int storeId { get; set; }
        //public int GetStoreId()
        //{
        //    return this.store.Id;
        //}

        public override string ToString()
        {
            return $"Beer: {Name} inventory: {Stock} price: ${Price}";
        }
     
    }
}