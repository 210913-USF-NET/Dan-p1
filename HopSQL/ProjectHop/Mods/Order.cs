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

        //public string DateNoTime = this.GetDateNoTime();
        
        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            } 
            set
            {

                if (value != 0)
                {
                    _quantity = value;
                }
                else
                {
                    InputInvalidException e = new InputInvalidException("Quantity must not be 0");
                    throw e;
                }
            }
        }

        public Mods.Beer SelectedBeer
        {get; set;}

        public int SelectedBeerId
        { get; set; }

        public int CustomerIndex
        { get; set; }

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

        public string GetDateNoTime()
        {
            return this.Date.ToString("MM/dd/yyyy");
        }

        public override string ToString()
        {
            return $" Date: {Date.ToString("MM/dd/yyyy")}  |   Customer Id: {CustomerId} \n   |   Beer: {SelectedBeer.Name}-${SelectedBeer.Price}   |  Quantity: {Quantity}    |  Total: ${GetTotal()} \n";
        }
        
    }
    
}