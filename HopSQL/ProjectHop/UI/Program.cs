using System;
using System.Collections.Generic;
using Bus;
using Mods;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //new MainMenu().Start();
            MenuFactory.GetMenu("login").Start();
        }
    }
}
