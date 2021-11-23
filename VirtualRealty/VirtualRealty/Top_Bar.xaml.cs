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
        private HashSet<HomeType> homeTypes;
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

        private void Search(object sender, RoutedEventArgs e)
        {

        }

        private void HomeTypeChecked(object sender, RoutedEventArgs e)
        {

        }

        private void HomeTypeUnchecked(object sender, RoutedEventArgs e)
        {

        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = "";
            box.GotFocus -= TextBox_GotFocus;
        }

        // If the user deselects textbox and leaves it blank, display default message
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Enter your city or neighbourhood";
                box.GotFocus += TextBox_GotFocus;
            }
        }

    }

}
