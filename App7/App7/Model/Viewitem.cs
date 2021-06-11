using System;

namespace App7.Model
{
    public class Viewitem
    {
        public int Order_item_id { get; set; }
        public string OrderItemCustomComment { get;set;}
        public double Quantity { get; set; }
        public string Productname { get; set; }
        public bool IsCanceled { get; set; }  
        public bool IsDelivered { get; set; }
        public string Preferences { get; set; }
        public double TotalQuantity { get; set; }
        public DateTime? PlacedOrderItem { get; set; }
        public bool HasWeight { get; set; }

    }
}
