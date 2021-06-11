
using Xamarin.Forms;

namespace App7.CustomListView
{
    public class SelectableItem : BindableObject
    {

        public static readonly BindableProperty DataProperty =
         BindableProperty.Create(
             nameof(Data),
             typeof(object),
             typeof(SelectableItem),
             (object)null);

        /*
        
        public static readonly BindableProperty IsCanceledProperty =
            BindableProperty.Create(
                nameof(IsCanceled),
                typeof(bool),
                typeof(SelectableItem),
                false);
        */

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(
                nameof(IsSelected),
                typeof(bool),
                typeof(SelectableItem),
                false);

        public SelectableItem()
        {
            IsSelected = false;
        }

        //Constructor with data parameter in it 
        public SelectableItem(object data)
        {
            Data = data;
            IsSelected = false;         
        }

        //Constructor with both data & IsSelected parameters in it 
        public SelectableItem(object data, bool isSelected) //, bool isCanceled
        {
            Data = data;
            IsSelected = isSelected;
         
        }

        //Data object property
        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        //IsSelected bool property
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

 
    }



    public class SelectableItem<T> : SelectableItem
    {
        public SelectableItem()
        {
        }

        //  public SelectableItem(T data)
        //     : base(data)
        //  {
        //  }

        public SelectableItem(T data, bool isSelected)//, bool isCanceled
            : base(data, isSelected ) //,  isCanceled
        {
        }

        // this is safe as we are just returning the base value
        public new T Data
        {
            get { return (T)base.Data; }
            set { base.Data = value; }
        }

    }


}
