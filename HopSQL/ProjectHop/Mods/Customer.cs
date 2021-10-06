using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mods
{
    public class Customer
    {
        public int Id 
        {get; set;}

        public int Code
        {get; set;}

        public string Name
        {get; set;}

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