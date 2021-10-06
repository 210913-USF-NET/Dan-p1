using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Bus;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string a)
        {
            string connectionString = File.ReadAllText(@"../connectionString.txt");
            DbContextOptions<HopDBContext> options = new DbContextOptionsBuilder<HopDBContext>().UseSqlServer(connectionString).Options;
            HopDBContext context = new HopDBContext(options);
            switch (a.ToLower())
            {
                case "beer":
                    return new BeerMenu(new BL(new DBRepo(context)));
                case "main":
                    return new MainMenu(new BL(new DBRepo(context)));
                case "login":
                    return new LoginMenu(new BL(new DBRepo(context))); 
                case "manager":
                    return new ManagerMenu(new BL(new DBRepo(context)));   
                default:
                    return null;
            }
        }
    }
}