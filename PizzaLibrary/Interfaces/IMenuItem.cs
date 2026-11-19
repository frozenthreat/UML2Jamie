using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary
{
    public interface IMenuItem
    {
        string Description { get; set; }
        string Name { get; set; }
        int No { get; }
        double Price { get; set; }
        MenuType TheMenuType { get; set; }

        string ToString();
    }

}
