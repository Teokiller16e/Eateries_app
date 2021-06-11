using Acr.UserDialogs;
using App7.CustomListView;
using App7.Model;
using App7.Services;
using App7.ViewModel;
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
    public class Done_ViewModel : INotifyPropertyChanged
    {
        public KDSService kdsservice { get; set; }

        private ICommand _selectedItemCommand;

        private int _counter2;
    
        public KDSOrders TestList { get; set; }
        public List<Vieworder> ViewOrders { get; set; }
        public Viewitem viewitem;
        public Vieworder tempVieworder;
        public SelectableItem<Viewitem> b { get; set; }
        public List<int> Daily_id_list { get; set; }
        public KDSService kds_Service { get; set; }
        public List<Vieworder> Activeorders { get; set; }
        public IList<Vieworder> MainLista { get; set; }
        public int QuantCounter { get; set; }
        public bool Connection  { get; set; }
        public ICommand SelectedItemCommand => _selectedItemCommand ?? (_selectedItemCommand = new Command((selectedItem) => Select((SelectableItem<Viewitem>)selectedItem)));

        public Done_ViewModel()
        {
             
             MessagingCenter.Subscribe<KDSService>(this, "NoConnection", (sender) => {
                Connection = true;
                OnPropertyChanged("Connection");
            });

            MessagingCenter.Subscribe<KDSService>(this, "Connection", (sender) => {
                Connection = false;
                OnPropertyChanged("Connection");
            });
            
            MessagingCenter.Subscribe<App>(this, "InitializeDone", (sender) => {
                Refresh();
            });

            MessagingCenter.Subscribe<Test_Settings>(this, "InitializeDone", (sender) => {
                Refresh();
            });


            Task.Run( () =>
            {
                Initialize(RefreshClass.Choice);
                App._timer.Start();
            });

            SettingsViewModel.FlagVariable = 2;

        }

        public  void Refresh()
        {
            App._timer.Stop();
            Initialize(RefreshClass.Choice);
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


        public void Initialize(int Choice)
        {
            MainLista = new ObservableCollection<Vieworder>();

            try
            {
                kdsservice = new KDSService();
                TestList = kdsservice.GetAllOrdersKds(BaseService.Kds_Code);
                if (TestList != null)
                {
                    Parse_orders();

                    switch (Choice)
                    {

                        case 1:
                            Counter2 = 1;
                            break;

                        case 2:
                            Counter2 = 2;
                            break;

                        case 3:
                            Counter2 = 3;
                            break;

                        case 4:
                            Counter2 = 4;
                            break;

                        default: Counter2 = 1; break;
                    }

                    OnPropertyChanged("Counter2");
                }

            }
            catch (Exception e)
            {

                UserDialogs.Instance.ShowError("The program wasn't able to continue cause of connection", 20000);

            }

        }


        public void Parse_orders()
        {

            QuantCounter = 0;
              Daily_id_list = new List<int>();
              Activeorders = new List<Vieworder>();
            //Daily_id_list.Clear();
            //Activeorders.Clear();
  


            foreach (var item in TestList.GetKDSOrdersResult)
            {

                if (!(Daily_id_list.Contains(item.DailyID)))
                {

                    Daily_id_list.Add(item.DailyID);
                    //bool isInList = intList.IndexOf(intVariable) != -1;   

                }

            }

            foreach (var item in Daily_id_list)
            {

                Vieworder created = new Vieworder();

                created.Items = new ObservableCollection<SelectableItem<Viewitem>>();

                created.Dailyid = item;

                foreach (var item2 in TestList.GetKDSOrdersResult)
                {

                    if (item2.DailyID == item)
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
                           
                        };

                        b = new SelectableItem<Viewitem>(a , false );

                        //ananewnw to vieworder

                        created.Last_Placed = item2.Placed;
                        created.OrderCustomComment = item2.OrderCustomComment;
                        created.Staffname = item2.StaffName;
                        created.Tablename = item2.TableName;
                        created.IsCompleted = true;
                        created.OrderTime = item2.Placed.Value.Hour + " : " + item2.Placed.Value.Minute;
                     
                        OnPropertyChanged("created");
                        created.Items.Add(b);
                       
                    }

                }


                foreach (var viewitem in created.Items)
                {

                    if (viewitem.Data.IsCanceled == false && viewitem.Data.IsDelivered == false)
                    {
                        created.IsCompleted = false;
                    }

                }

                if (created.IsCompleted == true)
                {
           
                    Activeorders.Add(created);

                }

            }


            
            Activeorders = Activeorders.OrderBy(x => x.Dailyid).ToList();
            //OnPropertyChanged("Activeorders");

            MainLista = Activeorders;
         
            OnPropertyChanged("MainLista");

            
        }
        
        public int Counter2
        {
            get { return _counter2; }
            set { _counter2 = value;  }
        }


    

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       

    }
}
