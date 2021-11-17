using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;


namespace VirtualRealty
{
    /// <summary>
    /// Interaction logic for Top_Bar.xaml
    /// </summary>
    public partial class Top_Bar : UserControl
    {
        public Top_Bar()
        {
            InitializeComponent();

            List<HomeType> homeTypeList = new List<HomeType>();
            homeTypeList.Add(new HomeType(false, "Apartment"));
            homeTypeList.Add(new HomeType(false, "Condo"));
            homeTypeList.Add(new HomeType(false, "House"));
            homeTypeList.Add(new HomeType(false, "Townhouse"));


            HomeType.ItemsSource = homeTypeList;
        }

        void GoToFavorites(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Favorites());
        }

        void GoToSavedSearches(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new SavedSearches());
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class HomeType
    {
        public HomeType(bool isChecked, string homeTypeName)
        {
            IsChecked = isChecked;
            HomeTypeName = homeTypeName;
        }

        public bool IsChecked
        { get; set; }

        public string HomeTypeName
        { get; set; }

    }
}
