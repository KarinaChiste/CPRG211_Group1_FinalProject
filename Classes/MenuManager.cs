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

        public static MenuItem CreateMenuItem(string itemId, string itemName, string price, string itemType)
        {
            MenuItem item = null;

            if (itemType == "Appetizer")
            {
                item = new AppetizerType(itemId, itemName, price, itemType);
                menuItems.Add(item);
            }

            if (itemType == "Main")
            {
                item = new MainType(itemId, itemName, price, itemType);
                menuItems.Add(item);
            }

            if (itemType == "Side")
            {
                item = new SideType(itemId, itemName, price, itemType);
                menuItems.Add(item);
            }

            if (itemType == "Dessert")
            {
                item = new DessertType(itemId, itemName, price, itemType);
                menuItems.Add(item);
            }

            if (itemType == "Drink")
            {
                item = new DrinkType(itemId, itemName, price, itemType);
                menuItems.Add(item);
            }

            //RestaurantDbAccessor db = new RestaurantDbAccessor();
            //db.AddItem(item);
            return item;
        }

    }
}
