using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Group1_FinalProject.Classes
{
    //Displays orders (NOT FULLY IMPLEMENTED)
    internal class Order
    {
        string OrderNum {  get; set; }
        public string ItemNum { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        //itemsOrdered will be the names of each item ordered seperated by a comma
        public Order(   string orderNum,
                        string itemNum,
                        string itemName,
                        int quantity)
        {
            OrderNum = orderNum;
            ItemNum = itemNum;
            ItemName = itemName;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Order Number:{OrderNum}, Item Number:{ItemNum}, Item Name:{ItemName}, Quantity:{Quantity}";
        }
    }
}