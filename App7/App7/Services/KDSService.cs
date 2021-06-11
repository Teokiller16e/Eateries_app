using Acr.UserDialogs;
using App7.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace App7.Services
{
    public class KDSService : BaseService
    {
        string result;

        public KDSOrders GetAllOrdersKds(int kdsCode)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(25);
                    var response = client.GetAsync($"{BaseURL}/order/GetKDSOrders?kdscode={kdsCode}").Result;                    
                    result = response.Content.ReadAsStringAsync().Result;

                }
                BaseService.BaseStatus = "Connected";
                //OnPropertyChanged("BaseStatus");
                MessagingCenter.Send<KDSService>(this, "Connection");
                return JsonConvert.DeserializeObject<KDSOrders>(result);
            }

            catch (Exception x)
            {
                BaseService.BaseStatus = "Disconnected";

                MessagingCenter.Send<KDSService>(this, "NoConnection");

                var mes = x.Message;
                return null;

            }

        }


        public void  OrderItemDelivered (int id, bool isDelivered,int quantity)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    var response = client.GetAsync($"{BaseURL}/order//OrderItemDelivered2?id={id}&quantity={quantity}&isDelivered={isDelivered}").Result;

                    result = response.Content.ReadAsStringAsync().Result;

                    //  var response = client.GetAsync($"{BaseURL}/order/get?id={tableId}").Result;
                    ///  result = response.Content.ReadAsStringAsync().Result;
                }
            }

            catch (Exception x)
            {
                var mes = x.Message;
            }

            //return JsonConvert.DeserializeObject<KDSOrders>(result);

        }


    }
   
}
