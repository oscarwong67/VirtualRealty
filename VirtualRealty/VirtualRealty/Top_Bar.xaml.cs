using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VirtualRealty
{
    /// <summary>
    /// Interaction logic for Top_Bar.xaml
    /// </summary>
    public partial class Top_Bar : UserControl
    {
        private string locationInput;
        private string savedSearchName;
        private int priceMin = -1;
        private int priceMax = -1;
        private HashSet<HomeType> homeTypes = new HashSet<HomeType>();
        private int numBedMin = -1;
        private int numBedMax = -1;
        private double numBathMin = -1;
        private double numBathMax = -1;
        private int sqftMin = -1;
        private int sqftMax = -1;
        private int ageOfListing = -1;
        private int yearBuiltMin = -1;
        private int yearBuiltMax = -1;
        private bool garage;
        private bool washerDryer;
        private bool isPurchase;

        public Top_Bar()
        {
            InitializeComponent();
            savedSearchName = "Name this Search";

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
           MainWindow.savedSearchesPage.load();
            
            Switcher.Switch(MainWindow.savedSearchesPage);        
        }

        private void ToggleSavingSearch(object sender, RoutedEventArgs e)
        {
            SavingSearch.IsOpen = !SavingSearch.IsOpen;
        }

        private void PriceMinInput_GotFocus(object sender, RoutedEventArgs e)
        {
            MinPriceOptions.Visibility = Visibility.Visible;
            TextBox box = sender as TextBox;
            if (box.Text != "Min") { return; }
            box.Text = "";
            box.GotFocus -= PriceMinInput_GotFocus;
        }

        // If the user deselects textbox and leaves it blank, display default message
        private void PriceMinInput_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Min";
                box.GotFocus += PriceMinInput_GotFocus;
            }
        }

        private void PriceMinInput_TextChanged(object sender, RoutedEventArgs e)
        {
            if (PriceMinInput.Text != null && PriceMinInput.Text.Length > 0 && PriceMinInput.Text[0] == '$')
            {
                PriceMinInput.Text = PriceMinInput.Text.Substring(1);
            }
            if (PriceMinInput.Text != null && PriceMinInput.Text.Length > 0 && PriceMinInput.Text != "Min")
            {
                if (PriceMinInput.Text[PriceMinInput.Text.Length - 1] == '+')
                {
                    priceMin = Int32.Parse(PriceMinInput.Text.Substring(0, PriceMinInput.Text.Length - 1), System.Globalization.NumberStyles.AllowThousands);
                } else
                {
                    priceMin = Int32.Parse(PriceMinInput.Text, System.Globalization.NumberStyles.AllowThousands);
                }
            }
        }

        private void PriceMaxInput_GotFocus(object sender, RoutedEventArgs e)
        {
            MaxPriceOptions.Visibility = Visibility.Visible;
            MinPriceOptions.Visibility = Visibility.Hidden;
            TextBox box = sender as TextBox;
            if (box.Text != "Max") { return; }
            box.Text = "";
            box.GotFocus -= PriceMaxInput_GotFocus;
        }

        // If the user deselects textbox and leaves it blank, display default message
        private void PriceMaxInput_LostFocus(object sender, RoutedEventArgs e)
        {
            MaxPriceOptions.Visibility = Visibility.Hidden;
            MinPriceOptions.Visibility = Visibility.Visible;
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Max";
                box.GotFocus += PriceMaxInput_GotFocus;
            }
        }

        private void PriceMaxInput_TextChanged(object sender, RoutedEventArgs e)
        {
            if (PriceMaxInput.Text != null && PriceMaxInput.Text.Length > 0 && PriceMaxInput.Text[0] == '$')
            {
                PriceMaxInput.Text = PriceMaxInput.Text.Substring(1);
            }
            if (PriceMaxInput.Text != null && PriceMaxInput.Text.Length > 0 && PriceMaxInput.Text != "Max")
            {
                priceMax = Int32.Parse(PriceMaxInput.Text, System.Globalization.NumberStyles.AllowThousands);
                if (PriceMinInput.Text != null && PriceMinInput.Text.Length > 0 && PriceMinInput.Text[PriceMinInput.Text.Length - 1] == '+')
                {
                    PriceMinInput.Text = PriceMinInput.Text.Substring(0, PriceMinInput.Text.Length - 1);
                }
            } else if (PriceMaxInput.Text != null && PriceMaxInput.Text.Length > 0 && PriceMaxInput.Text == "Max")
            {
                priceMax = -1;
            }
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
            savedSearchName = NameThisSearch.Text;
        }

        private async void SaveSearch(object sender, RoutedEventArgs e)
        {
            SavedSearch savedSearch = new SavedSearch();
            if (savedSearch.LocationSearchString != null && savedSearch.LocationSearchString.Length > 0)
            {
                savedSearch.LocationSearchString = locationInput;
            }
            // TODO (Oscar): validation
            savedSearch.SearchName = savedSearchName;
            if (priceMin >= 0)
            {
                savedSearch.MinPrice = priceMin;
            }
            if (priceMax >= 0)
            {
                savedSearch.MaxPrice = priceMax;
            }
            savedSearch.HomeType = new List<HomeType>(homeTypes);
            if (sqftMin >= 0)
            {
                savedSearch.MinSqFt = sqftMin;
            }
            if (sqftMax >= 0)
            {
                savedSearch.MaxSqFt = sqftMax;
            }
            if (numBedMin >= 0)
            {
                savedSearch.MinBeds = numBedMin;
            }
            if (numBedMax >= 0)
            {
                savedSearch.MaxBeds = numBedMax;
            }
            if (numBathMin >= 0)
            {
                savedSearch.MinBaths = numBathMin;
            }
            if (numBathMax >= 0)
            {
                savedSearch.MaxBaths = numBathMax;
            }
            if (garage)
            {
                savedSearch.HasGarage = garage;
            }
            if (ageOfListing >= 0)
            {
                savedSearch.MaxAgeOfListingInDays = ageOfListing;
            }
            if (yearBuiltMin >= 0)
            {
                savedSearch.MinYearBuilt = yearBuiltMin;
            }
            if (yearBuiltMax >= 0)
            {
                savedSearch.MaxYearBuilt = yearBuiltMax;
            }
            if (washerDryer)
            {
                savedSearch.HasWasherDryer = washerDryer;
            }
            savedSearch.LastAccessed = DateTime.Now;
            savedSearch.DateSaved = DateTime.Now;
            SavedSearches.savedSearches.Add(savedSearch);

            ToggleSavingSearch(sender, e);
            SavedSearchesButton.BorderBrush = Brushes.Green;
            SavedSearchesButton.BorderThickness = new Thickness(3);

            SavingSearchSuccess.IsOpen = true;
            await Task.Delay(1); // wait 1s
            for (int i = 99; i >= 0; i--)
            {
                SavingSearchSuccessContent.Opacity = i / 100d;
                if (i % 12 == 0)
                {
                    if (SavedSearchesButton.BorderBrush == Brushes.Green)
                    {
                        SavedSearchesButton.BorderBrush = Brushes.LightGreen;
                    } else
                    {
                        SavedSearchesButton.BorderBrush = Brushes.Green;
                    }
                }

                await Task.Delay(3); // The animation will take 3 seconds
            }
            SavingSearchSuccess.IsOpen = false;
            SavingSearchSuccessContent.Opacity = 1;
            SavedSearchesButton.BorderBrush = Brushes.Gray;
            SavedSearchesButton.BorderThickness = new Thickness(1);
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

        private void UseExactMatchChecked(object sender, RoutedEventArgs e)
        {
            BedOne.Content = "1";
            BedTwo.Content = "2";
            BedThree.Content = "3";
            BedFour.Content = "4";
            BedFive.Content = "5";
        }

        private void UseExactMatchUnchecked(object sender, RoutedEventArgs e)
        {
            BedOne.Content = "1+";
            BedTwo.Content = "2+";
            BedThree.Content = "3+";
            BedFour.Content = "4+";
            BedFive.Content = "5+";
        }

        private void NumBedCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Content.ToString().Equals("Any"))
            {
                numBedMin = -1;
                numBedMax = -1;

            }  else if (rb.Content.ToString().Equals("1+"))
            {
                numBedMin = 1;
                numBedMax = -1;

            } else if (rb.Content.ToString().Equals("2+"))
            {
                numBedMin = 2;
                numBedMax = -1;

            } else if (rb.Content.ToString().Equals("3+"))
            {
                numBedMin = 3;
                numBedMax = -1;

            } else if (rb.Content.ToString().Equals("4+"))
            {
                numBedMin = 4;
                numBedMax = -1;

            }  else if (rb.Content.ToString().Equals("5+"))
            {
                numBedMin = 5;
                numBedMax = -1;

            }
        }
        private void NumBathCheck(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb.Name == "BathAny")
            {
                numBathMin = -1;
            } else if (rb.Name == "BathOne")
            {
                numBathMin = 1;
            } else if (rb.Name == "BathOneHalf")
            {
                numBathMin = 1.5;
            } else if (rb.Name == "BathTwo")
            {
                numBathMin = 2;
            } else if (rb.Name == "BathThree")
            {
                numBathMin = 3;
            } else if (rb.Name == "BathFour")
            {
                numBathMin = 4;
            }
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
                } else if (cb.Name == HomeType.Condo.ToString())
                {
                    home = HomeType.Condo;
                    homeTypes.Add(home);
                } else if (cb.Name == HomeType.House.ToString())
                {
                    home = HomeType.House;
                    homeTypes.Add(home);
                } else if (cb.Name == HomeType.Townhouse.ToString())
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
                } else if (cb.Name == HomeType.Condo.ToString())
                {
                    home = HomeType.Condo;
                    homeTypes.Remove(home);
                } else if (cb.Name == HomeType.House.ToString())
                {
                    home = HomeType.House;
                    homeTypes.Remove(home);
                } else if (cb.Name == HomeType.Townhouse.ToString())
                {
                    home = HomeType.Townhouse;
                    homeTypes.Remove(home);
                }
            }
        }

        private void PurchaseCheck(object sender, RoutedEventArgs e)
        {
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

        private void ChooseMinPriceInput(object sender, MouseButtonEventArgs e)
        {
            priceMin = Int32.Parse((sender as TextBlock).Tag as String);
            PriceMinInput.Text = (sender as TextBlock).Text;
            MaxPriceOptions.Visibility = Visibility.Visible;
        }

        private void ChooseMaxPriceInput(object sender, MouseButtonEventArgs e)
        {
            priceMax = Int32.Parse((sender as TextBlock).Tag as String);
            PriceMaxInput.Text = (sender as TextBlock).Text;
        }
    }

}
