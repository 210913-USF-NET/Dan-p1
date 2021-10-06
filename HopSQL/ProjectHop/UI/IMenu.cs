using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mods;

namespace UI
{
    public interface IMenu
    {
       void Start(); 
       void Start(Store store);
    }
}