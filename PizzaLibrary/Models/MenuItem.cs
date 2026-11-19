using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary
{
    public class MenuItem:IMenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public MenuType TheMenuType { get; set; }
        public int No { get; private set; }
        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            ++No;
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
        }

        public override string ToString()
        {
            return $"Name: {Name}; Price: {Price}; Description: {Description}; Menu type: {TheMenuType}";
        }
    }
}
