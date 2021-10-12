using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
// using Serilog;

namespace Mods
{
    public class Customer
    {
        public int Id 
        {get; set;}

        public int Code
        {get; set;}

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(value.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Customer name can't be empty");
                    throw e;
                }
                else
                {
                    _name = value;
                }
            }
        }

        public bool IsManager
        {get; set;}
        // public List<Order> orders
        // {get; set;}

        // public void AddAnOrder(Order order)
        // {
        //     this.orders.Add(order);
        // }

        public override string ToString()
        {
            return Name;
        }

    }
}