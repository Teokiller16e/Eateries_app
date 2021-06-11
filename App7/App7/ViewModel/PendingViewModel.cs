using Acr.UserDialogs;
using App7.CustomListView;
using App7.Model;
using App7.Services;
using App7.ViewModel;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App7
{
    public class PendingViewModel : INotifyPropertyChanged
    {
        //Μεταβλητές :       
        public INavigation Navigation { get; set; }
        SelectableItem<Viewitem> b { get; set; }
        private ICommand _selectedItemCommand;
        private int _counter;
        SoundService soundService = new SoundService();
        public KDSOrders TestList { get; set; }
        public List<Vieworder> ViewOrders {get; set;}
        public Viewitem viewitem;
        public Vieworder tempVieworder;
        public List<int> Daily_id_list { get; set; }
        public KDSService kds_Service { get; set; }
        public List<Vieworder> Activeorders { get; set; }
        public IList<Vieworder> MainLista { get; set; }
        public int Last_Order_Id { get; set; }
        public int QuantCounter { get; set; }
        public DateTime StartTime { get; set; }
        public bool Connection { get; set; }
        private string _nowtime;
        public ICommand SelectedItemCommand => _selectedItemCommand ?? (_selectedItemCommand = new Command((selectedItem) => Select((SelectableItem<Viewitem>)selectedItem)));
         

        public PendingViewModel(INavigation navigation)
        {
            Navigation = navigation;
            
            MessagingCenter.Subscribe<KDSService>(this, "NoConnection", (sender) => {
                Connection = true;
                OnPropertyChanged("Connection");
            });
            MessagingCenter.Subscribe<KDSService>(this, "Connection", (sender) => {
                Connection = false;
                OnPropertyChanged("Connection");
            });
            MessagingCenter.Subscribe<App>(this, "InitializePending", (sender) => {
                Refresh();
            });

            MessagingCenter.Subscribe<Test_Settings>(this, "InitializePending", (sender) => {
                Refresh();
            });

            Task.Run(async () =>
            {
                await InitializeAsync(RefreshClass.Choice);
                App._timer.Start();
             });
            SettingsViewModel.FlagVariable = 1;

           
        }

    

        public async void Refresh()
        {
            App._timer.Stop();
            //await Task.Run(() => InitializeAsync(RefreshClass.Choice));
            await InitializeAsync(RefreshClass.Choice);
            App._timer.Start();
        }


        private void Select(SelectableItem<Viewitem> selecteditem)
        {

            if (selecteditem != null)
            {
                App._timer.Stop();
                App._timer.Start();

                selecteditem.IsSelected = !selecteditem.IsSelected;
            }

        }


        public async Task InitializeAsync(int Choice)
        {

            //MainLista.Clear();

            MainLista = new ObservableCollection<Vieworder>();
            //Law and Order Sound Effect

            try
            {
                await Task.Run(() =>
                {
                    // CacheData.Testlist.Clear();
                    NowTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                    //NowTime = DateTime.Now.ToString()
                    // kds_Service = new KDSService();
                    kds_Service = new KDSService();
                    TestList = kds_Service.GetAllOrdersKds(BaseService.Kds_Code);

                    if (TestList != null)
                    {
                         Parse_orders();

                        switch (Choice)
                        {

                            case 1:
                                Counter = 1;
                                break;

                            case 2:
                                Counter = 2;
                                break;

                            case 3:
                                Counter = 3;
                                break;

                            case 4:
                                Counter = 4;
                                break;

                            default: Counter = Counter; break;

                        }

                        OnPropertyChanged("Counter");
                    }

                });
              

            }


            catch (Exception e)
            {
               UserDialogs.Instance.ShowError("The program wasn't able to continue cause of connection", 20000);
            }


        }


        public  void Parse_orders()
        {
               
               QuantCounter = 0;
                
               Daily_id_list = new List<int>();

               Activeorders = new List<Vieworder>();

               // Daily_id_list.Clear();

               // Activeorders.Clear();

               //Εδώ γεμίζουμε το πεδίο totalquantity για να μπορούμε να δείξουμε την ποσότητα των ίδιων προιόντων :

                foreach(var test in TestList.GetKDSOrdersResult)
                {        
                

                    for(int i=0; i<TestList.GetKDSOrdersResult.Count; i++)
                    {


                        if (!(Daily_id_list.Contains(test.DailyID)))
                        {
                            Daily_id_list.Add(test.DailyID);
                            
                            //bool isInList = intList.IndexOf(intVariable) != -1;   
                        }


                        if(Last_Order_Id < test.DailyID)
                        {
                            Last_Order_Id = test.DailyID;
                        }


                        if (test.ProductName == TestList.GetKDSOrdersResult.ElementAt(i).ProductName && test.PreferencesString == TestList.GetKDSOrdersResult.ElementAt(i).PreferencesString &&
                            test.OrderItemCustomComment==TestList.GetKDSOrdersResult.ElementAt(i).OrderItemCustomComment &&TestList.GetKDSOrdersResult.ElementAt(i).IsDelivered==false)
                        {
                            QuantCounter = QuantCounter + Convert.ToInt32(TestList.GetKDSOrdersResult.ElementAt(i).Quantity);
                        }


                    }

                    test.Totalquantity = QuantCounter;
                    QuantCounter = 0;

                }

                if (Last_Order_Id > RefreshClass.Previous_Order_Id && Last_Order_Id!=0)          
                {                  

                    if (RefreshClass.Previous_Order_Id == 0)
                    {
                         RefreshClass.Previous_Order_Id = Last_Order_Id;
                    }

                    else
                    {

                        RefreshClass.Previous_Order_Id = Last_Order_Id;
                        soundService.PlaySoundAsync("sound.mp3");
                       
                    }
                   
                }

                foreach (var item in Daily_id_list)
                {
                    Vieworder created = new Vieworder();

                    created.Items = new ObservableCollection<SelectableItem<Viewitem>>();

                    //created.Items.Clear();

                    created.Dailyid = item;

                    foreach (var item2 in TestList.GetKDSOrdersResult)
                    {

                        if (item2.DailyID == item)
                        {

                            DateTime test = DateTime.Now;
                           int testtime = test.Minute + (test.Hour * 60);

                            if ( testtime - (item2.PlacedOrderItem.Value.Minute + (item2.PlacedOrderItem.Value.Hour * 60))  > BaseService.Hide_Delayed && item2.IsDelivered == true)
                            {

                            }

                            else
                            {
                                Viewitem a = new Viewitem
                                {

                                    IsCanceled = item2.IsCanceled,
                                    IsDelivered = item2.IsDelivered,
                                    OrderItemCustomComment = item2.OrderItemCustomComment,
                                    Order_item_id = item2.OrderItemId,
                                    Productname = item2.ProductName,
                                    Quantity = item2.Quantity,
                                    Preferences = item2.PreferencesString,
                                    TotalQuantity = (item2.Totalquantity - item2.Quantity),
                                    PlacedOrderItem = item2.PlacedOrderItem,
                                    HasWeight = item2.HasWeight

                                };

                                b = new SelectableItem<Viewitem>(a, false);
                                //SelectableItem<Viewitem> b = new SelectableItem<Viewitem>(a , false);

                                //ananewnw to vieworder
                                created.Last_Placed = item2.Placed;
                                created.OrderCustomComment = item2.OrderCustomComment;
                                created.Staffname = item2.StaffName;
                                created.Tablename = item2.TableName;
                                created.IsCompleted = true;
                                created.OrderTime = item2.Placed.Value.Hour + " : " + item2.Placed.Value.Minute;
                                
                                //created.Last_Placed.ToString()

                                StartTime = DateTime.Parse(created.Last_Placed.ToString());
                                TimeSpan Elapsed = new TimeSpan();
                                Elapsed = DateTime.Now.Subtract(StartTime);
                                created.TimeLeft = new double();
                                created.TimeLeft = Elapsed.Minutes + (Elapsed.Hours * 60);
                                OnPropertyChanged("created.TimeLeft");
                                created.Items.Add(b);
                            }

                        }                      

                    }
              
                        //Ξεχωρίζει τα Pending από όλες τις παραγγελίες με ένα property το :
                        foreach (var viewitem in created.Items)
                        {
                            
                            if(viewitem.Data.IsCanceled == false && viewitem.Data.IsDelivered == false)
                            {
                                created.IsCompleted = false;
                            }
                            
                        }

                            if (created.IsCompleted == false)
                            {
      
                                Activeorders.Add(created);

                            }
                           
                }
                      
                        Activeorders =  Activeorders.OrderBy(x => x.Dailyid).ToList();

                        //OnPropertyChanged("Activeorders");

                        MainLista = Activeorders;

                        OnPropertyChanged("MainLista");               
                       
        }

        // Property / Function List :

 
        public int Counter
        {
            get { return _counter; }
            set { _counter = value; OnPropertyChanged(); }
        }

        public string NowTime
        {
            get { return _nowtime; }
            set { _nowtime = value; OnPropertyChanged(); }
        }

        //Command για τα Έτοιμο Buttons μην χαθείς εδώ είμαστε 
        public Command ButtonCommand
        {
            //εβγαλα το kdsservice = new KDSSERVICE
            get
            {
                return new Command<Vieworder>(async(model) =>
                {
                
                    foreach (var item in model.Items)
                    {
                        if( item.Data.IsDelivered == false)
                        { 
                            if (item.IsSelected)
                            {

                                if(item.Data.Quantity>1 && item.Data.HasWeight == false)
                                {
                                    RefreshClass.Next_PopUp = false;
                                    
                                    //Flag = true;

                                    await Navigation.PushPopupAsync(new QuantityPopUp());    
                                    
                                    MessagingCenter.Send<PendingViewModel,SelectableItem<Viewitem>>(this, "Questions", item);

                                    while(RefreshClass.Next_PopUp == false)
                                    {
                                        await Task.Delay(1000);
                                    }
                                    //await InitializeAsync(RefreshClass.Choice);
                                   

                                }   

                                else
                                {
                                    kds_Service.OrderItemDelivered(item.Data.Order_item_id, true,0);
                                }
                            
                            }

                        }

                    }

                  //  if(Flag!=true)
                    await InitializeAsync(RefreshClass.Choice);

                });
            }

        }
     

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
