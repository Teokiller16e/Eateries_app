using Xamarin.Forms;

namespace App7.CustomListView
{
    [ContentProperty(nameof(DataView))]
    public  class SelectableViewCell : ViewCell
    {

        private Grid rootGrid;
        private View dataView;
        private View checkView;

        public SelectableViewCell()
        {

            rootGrid = new Grid
            {
                Padding = 0,
                ColumnDefinitions =
                {

                    new ColumnDefinition { Width = GridLength.Star }

                },
                RowDefinitions =
                {
                    new RowDefinition {Height = GridLength.Auto}
                }
            };

            View = rootGrid;


        }

        public View CheckView
        {
            get { return checkView; }
            set
            {
                // jump out if the value is the same or something happened to our layout
                if (checkView == value || View != rootGrid)
                    return;

                OnPropertyChanging();

                // remove the old binding
                if (checkView != null)
                {
                    checkView.RemoveBinding(VisualElement.IsVisibleProperty);
                    rootGrid.Children.Remove(checkView);
                }

                checkView = value;

                // add the new binding
                if (checkView != null)
                {
                    checkView.SetBinding(VisualElement.IsVisibleProperty, nameof(SelectableItem.IsSelected));
                    Grid.SetColumn(checkView, 0);
                    Grid.SetColumnSpan(checkView, 1);
                    Grid.SetRow(checkView, 0);
                    Grid.SetRowSpan(checkView, 1);
                    checkView.HorizontalOptions = LayoutOptions.FillAndExpand;
                    checkView.VerticalOptions = LayoutOptions.FillAndExpand;
                    rootGrid.Children.Add(checkView);
                }

                OnPropertyChanged();
            }
        }

        public View DataView
        {
            get { return dataView; }

            set
            {
                // jump out if the value is the same or something happened to our layout
                if (dataView == value || View != rootGrid)
                    return;

                OnPropertyChanging();

                // remove the old view
                if (dataView != null)
                {
                    dataView.RemoveBinding(BindingContextProperty);
                    rootGrid.Children.Remove(dataView);
                }

                dataView = value;

                // add the new view
                if (dataView != null)
                {

                    dataView.SetBinding(BindingContextProperty, nameof(SelectableItem.Data));
                    Grid.SetColumn(dataView, 0);
                    Grid.SetColumnSpan(dataView, 1);
                    Grid.SetRow(dataView, 0);
                    Grid.SetRowSpan(dataView, 1);
                    dataView.HorizontalOptions = LayoutOptions.Fill;
                    dataView.VerticalOptions = LayoutOptions.Fill;
                    rootGrid.Children.Add(dataView);

                }

                OnPropertyChanged();
            }
        }

    }
}
