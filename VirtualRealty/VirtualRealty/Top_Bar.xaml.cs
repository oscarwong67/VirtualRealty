﻿using System.Windows;
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
        private string locationInput;
        private int priceMin;
        private int priceMax;
        private HashSet<HomeType> homeTypes = new HashSet<HomeType>();
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
        private bool isPurchase;

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

        private void ToggleSavingSearch(object sender, RoutedEventArgs e)
        {
            SavingSearch.IsOpen = !SavingSearch.IsOpen;
        }

        private void NameThisSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = "";
            box.GotFocus -= NameThisSearch_GotFocus;
        }

        // If the user deselects textbox and leaves it blank, display default message
        private void NameThisSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Name This Search";
                box.GotFocus += NameThisSearch_GotFocus;
            }
        }

        private void NameThisSearch_TextChanged(object sender, RoutedEventArgs e)
        {
            locationInput = NameThisSearch.Text;
        }

        private void SaveSearch(object sender, RoutedEventArgs e)
        {
            SavedSearch savedSearch = new SavedSearch();
            savedSearch.LocationSearchString = locationInput;
            savedSearch.MinPrice = priceMin;
            savedSearch.MaxPrice = priceMax;
            savedSearch.HomeType = new List<HomeType>(homeTypes);
            savedSearch.MinSqFt = sqftMin;
            savedSearch.MaxSqFt = sqftMax;
            savedSearch.MinBeds = numBedMin;
            savedSearch.MaxBeds = numBedMax;
            savedSearch.MinBaths = numBathMin;
            savedSearch.MaxBaths = numBathMax;
            savedSearch.HasGarage = garage;
            savedSearch.MaxAgeOfListingInDays = ageOfListing;
            savedSearch.MinYearBuilt = yearBuiltMin;
            savedSearch.MaxYearBuilt = yearBuiltMax;
            savedSearch.HasWasherDryer = washerDryer;
            savedSearch.LastAccessed = DateTime.Now;
            savedSearch.DateSaved = DateTime.Now;
            SavedSearches.savedSearches.Add(savedSearch);

            ToggleSavingSearch(sender, e);
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

        private void NumBedCheck(object sender, RoutedEventArgs e)
        {

        }
        private void NumBathCheck(object sender, RoutedEventArgs e)
        {

        }
        private void HomeTypeChecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.IsChecked == true)
            {
                HomeType home;
                if (cb.Name == HomeType.Apartment.ToString())
                {
                    home = HomeType.Apartment;
                    homeTypes.Add(home);
                }
                if (cb.Name == HomeType.Condo.ToString())
                {
                    home = HomeType.Condo;
                    homeTypes.Add(home);
                }
                if (cb.Name == HomeType.House.ToString())
                {
                    home = HomeType.House;
                    homeTypes.Add(home);
                }
                if (cb.Name == HomeType.Townhouse.ToString())
                {
                    home = HomeType.Townhouse;
                    homeTypes.Add(home);
                }
            }
        }

        private void HomeTypeUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.IsChecked == false)
            {
                HomeType home;
                if (cb.Name == HomeType.Apartment.ToString())
                {
                    home = HomeType.Apartment;
                    homeTypes.Remove(home);
                }
                if (cb.Name == HomeType.Condo.ToString())
                {
                    home = HomeType.Condo;
                    homeTypes.Remove(home);
                }
                if (cb.Name == HomeType.House.ToString())
                {
                    home = HomeType.House;
                    homeTypes.Remove(home);
                }
                if (cb.Name == HomeType.Townhouse.ToString())
                {
                    home = HomeType.Townhouse;
                    homeTypes.Remove(home);
                }
            }
        }

        private void PurchaseCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if(Purchase.IsChecked == true)
            {
                isPurchase = true;
            } else
            {
                isPurchase = false;
            }
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
