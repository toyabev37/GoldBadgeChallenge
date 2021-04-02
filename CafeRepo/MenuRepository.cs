using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuDatabase = new List<MenuItem>();

        int _count;

        //CREATE
        public bool AddMenuItemToDatabase(MenuItem menu)
        {
            _count++;
            menu.MealNumber = _count;
            _menuDatabase.Add(menu);
            return true;
        }

        //DELETE
        public bool RemoveMenuItem(int menuMealNumber)
        {
            foreach (var menu in _menuDatabase)
            {
                if (menu.MealNumber == menuMealNumber)
                {
                    _menuDatabase.Remove(menu);
                    return true;
                }
            }
            return false;
        }

        //RECEIVE LIST
        public List<MenuItem> ReceiveListOfItems()
        {
            return _menuDatabase;
        }
        //RECEIVE A MENU ITEM
        public MenuItem GetMenuItemByMealNumber(int menuId)
        {
            foreach (var menuItem in _menuDatabase)
            {
                if (menuItem.MealNumber == menuId)
                {
                    return menuItem;
                }
            }
            return null;

        }
    }
}
