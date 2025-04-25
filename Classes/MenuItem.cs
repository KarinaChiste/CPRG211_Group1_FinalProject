using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Exceptions;

namespace CPRG211_Group1_FinalProject.Classes
{
    public abstract class MenuItem
    {
        private string itemId;
        private string itemName;
        private string price;
        private string itemType;

        public string ItemId { get => itemId; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Item ID:");
                }
                itemId = value;
            } 
        }

        public string ItemName { get => itemName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Item Name:");
                }
                itemName = value;
            }
        }

        public string Price { get => price;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Price:");
                }
                price = value;
            }
        }

        public string ItemType { get; set; }

        public MenuItem(string itemId, string itemName, string price, string itemType)
        {
            ItemId = itemId;
            ItemName = itemName;
            Price = price;
            ItemType = itemType;
        }

        public override string ToString()
        {
            return $"{ItemId}, {ItemName}, {Price}, {ItemType}";
        }

        public abstract string GetMenuItemType();

    }
}
