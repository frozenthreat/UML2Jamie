using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PizzaLibrary
{
    public class MenuItemRepository : IMenuItemRepository
    {
        public int Count { get { return _menuItemList.Count; } }
        private List<IMenuItem> _menuItemList;

        public MenuItemRepository()
        {
            //_menuItemList = new List<IMenuItem>();
            _menuItemList = MockData.MenuItemData;
        }

        public List<IMenuItem> GetAll()
        {
            return _menuItemList;
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            _menuItemList.Add(menuItem);
        }

        public IMenuItem GetMenuItemByNo(int no)
        {
            return _menuItemList[no - 1];
        }

        public void RemoveMenuItem(int no)
        {
            _menuItemList.RemoveAt(no - 1);
        }

        public void PrintAllMenuItems()
        {
            foreach (var item in _menuItemList)
            {
                Console.WriteLine(item);
            }
        }

        public List<IMenuItem>? FindAllItems(MenuType menuType)
        {
            List<IMenuItem>? typeList = new List<IMenuItem>();
            foreach (var item in _menuItemList)
            {
                if (item.TheMenuType == menuType)
                {
                    typeList.Add(item);
                }
            }
            return typeList;
        }

        public IMenuItem? FindMostExpensiveItem(MenuType menuType)
        {
            IMenuItem? mostExpensiveItem = null;
            foreach (var item in _menuItemList)
            {
                if (mostExpensiveItem == null)
                {
                    mostExpensiveItem = item;
                }
                if (item.TheMenuType == menuType && item.Price > mostExpensiveItem.Price)
                {
                    mostExpensiveItem = item;
                }
            }
            return mostExpensiveItem;
        }

        public IMenuItem? FindMostExpensivePizza()
        {
            IMenuItem? pizza1 = FindMostExpensiveItem(MenuType.PIZZECLASSSICHE);
            IMenuItem? pizza2 = FindMostExpensiveItem(MenuType.PIZZESPECIALI);
            if (pizza2.Price > pizza1.Price)
            {
                return pizza2;
            }
            return pizza1;
        }

        public static List<MenuType> MenuTypeList()
        {
            List<MenuType> enums = new List<MenuType>();
            enums.Add(MenuType.SANDWICHES);
            enums.Add(MenuType.BRUCHETTA_CROSTINO);
            enums.Add(MenuType.SALATER);
            enums.Add(MenuType.PIZZECLASSSICHE);
            enums.Add(MenuType.PIZZESPECIALI);
            enums.Add(MenuType.PASTAALFORNO);
            enums.Add(MenuType.TILBEHØR);
            return enums;
        }

        public void ListMenu()
        {
            //List<MenuType> menuTypes = Enum.GetValues<MenuType>().ToList();
            List<MenuType> menuTypes = MenuTypeList();
            foreach (var type in menuTypes)
            {
                Console.WriteLine($"{type}:");
                List<IMenuItem>? items = FindAllItems(type);
                if (items.Count == 0)
                {
                    Console.WriteLine($"We don't have {type}");
                }
                else foreach (var item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public List<IMenuItem>? MenuItemsInPriceRange(double min, double max)
        {
            List<IMenuItem> tempList = new List<IMenuItem>();
            foreach (var item in _menuItemList)
            {
                if (item.Price >= min && item.Price <= max)
                {
                    tempList.Add(item);
                }
            }
            return tempList;
        }

        public void UpdateMenuItem(int no, string name, double price, string description, MenuType menuType)
        {
            foreach (var item in _menuItemList)
            {
                if (item.No == no)
                {
                    item.Name = name;
                    item.Price = price;
                    item.Description = description;
                    item.TheMenuType = menuType;
                }
            }
        }
    }
}