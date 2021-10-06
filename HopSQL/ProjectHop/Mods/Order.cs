using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mods
{
    
        public class Order
    {
        public int Id 
        {get; set;}

        public System.DateTime Date 
        {get; set;}

        public int Quantity
        {get; set;}

        public Mods.Beer SelectedBeer
        {get; set;}

        public int CustomerIndex
        {get; set;}

        public int CustomerId
        { get; set; }

        public int LineItemId
        { get; set; }

        public int StoresId
        {get; set;}

        
        public virtual Customer Customer { get; set; }

        public virtual LineItem LineItem { get; set; }

        //private decimal TotalPrice = this.SelectedBeer.Price * this.Quantity;
        public decimal GetTotal()
        {
            decimal TotalPrice = this.SelectedBeer.Price * this.Quantity;
            return TotalPrice;
        }

        public override string ToString()
        {
            return $" Date: {Date.ToString("MM/dd/yyyy")} CustomerId: {CustomerIndex + 1} \n      Beer: {SelectedBeer.Name}-${SelectedBeer.Price} Quantity: {Quantity}\n";
        }
        
    }
    
}