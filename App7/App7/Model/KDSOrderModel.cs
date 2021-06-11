using System;
using System.Collections.Generic;

namespace App7
{
    public class KDSOrders
    {
       public List<KDSOrderModel> GetKDSOrdersResult { get; set; }
    }

    public class KDSOrderModel
    {

        public int OrderItemId { get; set; } //item
        public string OrderItemCustomComment { get; set; } //item
        public string PreferencesString { get; set; }  //item
        public double Quantity { get; set; } //item
        public string ProductName { get; set; } //item
        public string StaffName { get; set; } //global
        public string TableName { get; set; } //global
        public string OrderCustomComment { get; set; } //global
        public int DailyID { get; set; } //global
        public DateTime? Placed { get; set; }  //global
        public bool IsCanceled { get; set; }  //item
        public bool IsDelivered { get; set; }  //item
        public double Totalquantity { get ; set ; } //edw tha deixnoume poses fores yparxei to ekastote item 
        public DateTime? PlacedOrderItem { get; set; }
        public bool HasWeight { get; set; }

        //tha exei k ena bool totallive //item

    }
}
