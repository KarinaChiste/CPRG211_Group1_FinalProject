using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Classes
{
    class MenuManager
    {
        public static List<MenuItem> menuItems = new List<MenuItem>();

        public static List<MenuItem> GetMenuItems()
        {
            return menuItems;
        }

        public static MenuItem CreateMenuItem(string itemId, string itemName, string itemType, string price)
        {
            MenuItem item = null;

            if (itemType == "Appetizer")
            {
                item = new AppetizerType(itemId, itemName, itemType, price);
                menuItems.Add(item);
            }

            else if (itemType == "Main")
            {
                item = new MainType(itemId, itemName, itemType, price);
                menuItems.Add(item);
            }

            else if (itemType == "Side")
            {
                item = new SideType(itemId, itemName, itemType, price);
                menuItems.Add(item);
            }

            else if (itemType == "Dessert")
            {
                item = new DessertType(itemId, itemName, itemType, price);
                menuItems.Add(item);
            }

            else if (itemType == "Drink")
            {
                item = new DrinkType(itemId, itemName, itemType, price);
                menuItems.Add(item);
            }
            //THROW EXCEPTION IN ELSE STATEMENT

            MenuDbAccessor db = new MenuDbAccessor();
            db.AddMenuItem(item);
           
            return item;
        }
        public static void DeleteMenuItem(string itemId)
        {
            MenuDbAccessor db = new MenuDbAccessor();
            db.RemoveMenuItem(itemId);
        }

    }
}
