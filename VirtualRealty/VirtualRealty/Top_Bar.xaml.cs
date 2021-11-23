using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System;


namespace VirtualRealty
{
    /// <summary>
    /// Interaction logic for Top_Bar.xaml
    /// </summary>
    public partial class Top_Bar : UserControl
    {
        private int priceMin;
        private int priceMax;
        private List<HomeType> homeTypes;
        private int numBedMin;
        private int numBedMax;
        private int numBathMin;
        private int numBathMax;
        private int sqftMin;
        private int sqftMax;
        private int ageOfListing;
        private int yearBuiltMin;
        private int yearBuiltMax;
        private bool garage;
        private bool washerDryer;
        public Top_Bar()
        {
            InitializeComponent();

        }
        void GoToHomePage(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new ListingsPage());
        }

        void GoToFavorites(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Favorites());
        }

        void GoToSavedSearches(object sender, RoutedEventArgs e)
        {
            if (MainWindow.savedSearchesPage == null)
            {
                MainWindow.CreateInitialSavedSearches();
                MainWindow.savedSearchesPage = new SavedSearches();
            }
            Switcher.Switch(MainWindow.savedSearchesPage);        
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        void Search(object sender, RoutedEventArgs e)
        {

        }
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
        }

    }

}
