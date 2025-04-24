using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Classes
{
    class SideType : MenuItem
    {
        public SideType(string itemId, string itemName, string price, string itemType) : base(itemId, itemName, price, itemType)
        {
        }

        public override string GetMenuItemType()
        {
            return "Side";
        }
    }
}
