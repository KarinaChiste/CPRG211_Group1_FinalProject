using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPRG211_Group1_FinalProject.Exceptions;

namespace CPRG211_Group1_FinalProject.Classes
{
    //Creates abstract class for menu items and validates all inputs
    public abstract class MenuItem
    {
        private string itemId;
        private string itemName;
        private string itemType;
        private string price;

        public string ItemId { get => itemId; 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Item ID");
                }

                if (!int.TryParse(value, out int parsedId))
                {
                    throw new InvalidFormatException("Item ID must be a numeric value.");
                }

                if (parsedId < 0)
                {
                    throw new InvalidFormatException("Item ID cannot be negative.");
                }

                if (value.Length != 6)
                {
                    throw new InvalidFormatException("Item ID must be exactly 6 digits long.");
                }

                itemId = value;
            } 
        }

        public string ItemName { get => itemName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Item Name");
                }
                itemName = value;
            }
        }

        public string ItemType { get; set; }

        public string Price { get => price;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyFieldException("Price");
                }

                if (!decimal.TryParse(value, out decimal parsedPrice) || parsedPrice <= 0)
                {
                    throw new InvalidFormatException("Price must be a valid positive number.");
                }

                price = value;
            }
        }

        public MenuItem(string itemId, string itemName, string itemType, string price)
        {
            ItemId = itemId;
            ItemName = itemName;
            ItemType = itemType;
            Price = price;
        }

        public override string ToString()
        {
            return $"{ItemId}, {ItemName}, {ItemType}, {Price}";
        }

        public abstract string GetMenuItemType();

    }
}
