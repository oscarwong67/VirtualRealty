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
using System.Linq;

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
        private bool parking = false;
        private bool washerDryer = false;
        private bool isPurchase = true;

        // more filter counting
        private bool sizeSet;
        private bool maxAgeSet;
        private bool yearBuiltFilterSet;
        private bool parkingSet;
        private bool washerDryerSet;

        public Top_Bar()
        {
            InitializeComponent();
            savedSearchName = "Name this Search";
        }

        public void copyPropertiesFrom(Top_Bar other)
        {
            locationInput = other.locationInput;
            savedSearchName = other.savedSearchName;
            priceMin = other.priceMin;
            priceMax = other.priceMax;
            homeTypes = other.homeTypes;
            numBedMin = other.numBedMin;
            numBedMax = other.numBedMax;
            numBathMin = other.numBathMin;
            numBathMax = other.numBathMax;
            sqftMin = other.sqftMin;
            sqftMax = other.sqftMax;
            ageOfListing = other.ageOfListing;
            yearBuiltMin = other.yearBuiltMin;
            yearBuiltMax = other.yearBuiltMax;
            parking = other.parking;
            washerDryer = other.washerDryer;
            isPurchase = other.isPurchase;
            sizeSet = other.sizeSet;
        }

        void GoToHomePage(object sender, RoutedEventArgs e)
        {
            MainWindow.isLoaded = false;
            List<Listing> listings = Listing.FilterListings(MainWindow.Listings);
            MainWindow.LP = new ListingsPage();
            listings.Sort(new ListingComparer(ListingComparer.SortBy.DateListed));
            MainWindow.LP.SetListings(listings);
            Switcher.Switch(MainWindow.LP);
            MainWindow.LP.SortOrder.SelectedIndex = 0;
        }

        void GoToFavorites(object sender, RoutedEventArgs e)
        {
            MainWindow.isLoaded = false;
            MainWindow.FavouritesPage = new Favorites();
            Switcher.Switch(MainWindow.FavouritesPage);
            MainWindow.LP.ClearListings();
            MainWindow.MapViewPage.ClearListings();

            MainWindow.FavouritesPage.FavesTopBar.GoToFavoritesButton.BorderBrush = Brushes.SlateGray;
            MainWindow.FavouritesPage.FavesTopBar.GoToFavoritesButton.BorderThickness = new Thickness(2);
            MainWindow.FavouritesMapViewPage.FavesMapViewTopBar.GoToFavoritesButton.BorderBrush = Brushes.SlateGray;
            MainWindow.FavouritesMapViewPage.FavesMapViewTopBar.GoToFavoritesButton.BorderThickness = new Thickness(2);

            // i cannot believe
            List<Listing> listings = Listing.FilterListings(MainWindow.Listings, Favourite: true).ToList();
            listings.Sort(new ListingComparer(ListingComparer.SortBy.DateFavourited));
            MainWindow.FavouritesPage.SetListings(listings);

        }

        void GoToSavedSearches(object sender, RoutedEventArgs e)
        {
            MainWindow.isLoaded = false;
            MainWindow.savedSearchesPage.SavedSearchesTopBar.SavedSearchesButton.BorderBrush = Brushes.SlateGray;
            MainWindow.savedSearchesPage.SavedSearchesTopBar.SavedSearchesButton.BorderThickness = new Thickness(2);

            MainWindow.savedSearchesPage.load();

            Switcher.Switch(MainWindow.savedSearchesPage);
        }

        public void applyAllLabelText()
        {
            applyPriceInputLabelText();
            applyHomeTypeLabelText();
            applyBedBathLabelText();
            applyMoreFiltersLabelText();
        }

        private void OnLocationInputKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Search(sender, e);
            }
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (AgeListing == null || MainWindow.Listings == null || !(MainWindow.isLoaded))
            {
                return;
            }
            if (Location.Text != "Enter your city or neighborhood")
            {
                locationInput = Location.Text;
            }

            if (!AgeListing.Text.Equals("") && !AgeListing.Text.Equals("—"))
            {
                ageOfListing = Int32.Parse(AgeListing.Text);
            }

            List<HomeType> homeTypesList = homeTypes.ToList();

            string searchHeader = "Homes " + (isPurchase ? "for Purchase" : "for Rent") + ((locationInput != null && locationInput.Length > 0 && locationInput != "Enter your city or neighborhood") ? " near " + locationInput : "");
            if (this.Tag != null && this.Tag.Equals("FavoritesMapViewTopBar"))
            {
                MainWindow.FavouritesMapViewPage.SetListings(Listing.FilterListings(MainWindow.Listings, priceMin, priceMax, homeTypesList, numBedMin, numBedMax, numBathMin, numBathMax, sqftMin, sqftMax, ageOfListing, yearBuiltMin, yearBuiltMax, washerDryer, parking, isPurchase, Favourite: true, locationSearchString:locationInput));
                MainWindow.FavouritesPage.FavoritesLabel.Text = "Your Favorite " + searchHeader;
                MainWindow.FavouritesMapViewPage.FavoritesMapViewLabel.Text = "Your Favorite " + searchHeader;
                Switcher.Switch(MainWindow.FavouritesMapViewPage);
                MainWindow.isLoaded = false; // set this to false so we don't accidentally start searching
                MainWindow.FavouritesMapViewPage.FavesMapViewTopBar = this;
                // MainWindow.FavouritesMapViewPage.FavesMapViewTopBar.applyAllLabelText();
                MainWindow.isLoaded = true;
            } else if (this.Tag != null && this.Tag.Equals("FavoritesTopBar"))
            {
                MainWindow.FavouritesPage.SetListings(Listing.FilterListings(MainWindow.Listings, priceMin, priceMax, homeTypesList, numBedMin, numBedMax, numBathMin, numBathMax, sqftMin, sqftMax, ageOfListing, yearBuiltMin, yearBuiltMax, washerDryer, parking, isPurchase, Favourite: true, locationSearchString: locationInput));
                MainWindow.FavouritesPage.FavoritesLabel.Text = "Your Favorite " + searchHeader;
                MainWindow.FavouritesMapViewPage.FavoritesMapViewLabel.Text = "Your Favorite " + searchHeader;
                Switcher.Switch(MainWindow.FavouritesPage);
                MainWindow.isLoaded = false; // set this to false so we don't accidentally start searching
                MainWindow.FavouritesPage.FavesTopBar = this;
                // MainWindow.FavouritesPage.FavesTopBar.applyAllLabelText();
                MainWindow.isLoaded = true;
            } else if (this.Tag != null && this.Tag.Equals("MapViewTopBar")) {
                MainWindow.MapViewPage.SetListings(Listing.FilterListings(MainWindow.Listings, priceMin, priceMax, homeTypesList, numBedMin, numBedMax, numBathMin, numBathMax, sqftMin, sqftMax, ageOfListing, yearBuiltMin, yearBuiltMax, washerDryer, parking, isPurchase, locationSearchString: locationInput));
                MainWindow.LP.ListingsHeader.Text = searchHeader;
                MainWindow.MapViewPage.MapViewHeader.Text = searchHeader;
                Switcher.Switch(MainWindow.MapViewPage);
                MainWindow.isLoaded = false; // set this to false so we don't accidentally start searching
                MainWindow.MapViewPage.MapViewTopBar = this;
                // MainWindow.MapViewPage.MapViewTopBar.applyAllLabelText();
                MainWindow.isLoaded = true;
            } else
            {
                MainWindow.LP.SetListings(Listing.FilterListings(MainWindow.Listings, priceMin, priceMax, homeTypesList, numBedMin, numBedMax, numBathMin, numBathMax, sqftMin, sqftMax, ageOfListing, yearBuiltMin, yearBuiltMax, washerDryer, parking, isPurchase, locationSearchString: locationInput));
                MainWindow.LP.ListingsHeader.Text = searchHeader;
                MainWindow.MapViewPage.MapViewHeader.Text = searchHeader;
                Switcher.Switch(MainWindow.LP);
                MainWindow.isLoaded = false; // set this to false so we don't accidentally start searching
                // MainWindow.LP.LPTopBar.copyPropertiesFrom(this);
                MainWindow.LP.LPTopBar = this;
                // MainWindow.LP.LPTopBar.applyAllLabelText();
                MainWindow.isLoaded = true;
            }
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

            applyPriceInputLabelText();
            Search(sender, e);
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

        private void applyPriceInputLabelText()
        {
            if (priceMax > priceMin)
            {
                if (priceMin == -1)
                {
                    PriceInputLabel.Text = "$0k-" + priceMax / 1000 + "k";
                } else
                {
                    PriceInputLabel.Text = "$" + priceMin / 1000 + "k-" + priceMax / 1000 + "k";
                }
            }
            else if (priceMax == priceMin && priceMin != -1)
            {
                PriceInputLabel.Text = "$" + priceMax / 1000 + "k";
            } else if (priceMin != -1 && priceMax == -1)
            {
                PriceInputLabel.Text = "$" + priceMin / 1000 + "k+";
            } else if (priceMin == -1 && priceMax == -1)
            {
                PriceInputLabel.Text = "Price";
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

            applyPriceInputLabelText();
            Search(sender, e);
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
            box.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        // If the user deselects textbox and leaves it blank, display default message
        private void NameThisSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Name This Search";
                box.GotFocus += NameThisSearch_GotFocus;
                box.Foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85));
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
            if (parking)
            {
                savedSearch.HasParking = parking;
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
            savedSearch.IsPurchase = isPurchase;
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

        private void applyMoreFiltersLabelText()
        {
            if (MoreFiltersLabel == null) { return; }

        int filterCount = 0;
        if (sizeSet) {
                filterCount++;
        }
        if (maxAgeSet) {
            filterCount++;
        }
        if (yearBuiltFilterSet)
            {
                filterCount++;
            }
        if (parkingSet)
            {
                filterCount++;
            }
        if (washerDryerSet)
            {
                filterCount++;
            }
        if (filterCount == 0)
            {
                MoreFiltersLabel.Text = "More Filters";
            } else
            {

                MoreFiltersLabel.Text = "More Filters: " + filterCount;
            }
    }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void MinSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            if (cbi.Content.Equals("Any"))
            {
                sqftMin = -1;

                for (int i = 1; i < MaxSqFt.Items.Count; i++)
                {
                    ComboBoxItem item = (ComboBoxItem)MaxSqFt.Items[i];
                    int value = Int32.Parse(item.Content as string);
                    item.Visibility = Visibility.Visible;
                }
            } else
            {
                sqftMin = Int32.Parse(cbi.Content as string);

                if (MaxSqFt.SelectedIndex == -1 || MaxSqFt.SelectedIndex == 0)
                {
                    for(int i = 1; i < MaxSqFt.Items.Count; i++)
                    {
                        ComboBoxItem item = (ComboBoxItem)MaxSqFt.Items[i];
                        int value = Int32.Parse(item.Content as string);

                        if(value < sqftMin)
                        {
                            item.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
            if (sqftMin == -1 && sqftMax == -1)
            {
                sizeSet = false;
            } else
            {
                sizeSet = true;
            }
            applyMoreFiltersLabelText();
            Search(sender, e);
        }

        private void MaxSelected(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = (ComboBoxItem)(sender as ComboBox).SelectedItem;
            if (cbi.Content.Equals("Any"))
            {
                sqftMax = -1;

                for (int i = 1; i < MinSqFt.Items.Count; i++)
                {
                    ComboBoxItem item = (ComboBoxItem)MinSqFt.Items[i];
                    int value = Int32.Parse(item.Content as string);

                    item.Visibility = Visibility.Visible;
                }
            }
            else
            {
                sqftMax = Int32.Parse(cbi.Content as string);

                if(MinSqFt.SelectedIndex == -1 || MinSqFt.SelectedIndex == 0)
                {
                    for(int i = 1; i < MinSqFt.Items.Count; i++)
                    {
                        ComboBoxItem item = (ComboBoxItem)MinSqFt.Items[i];
                        int value = Int32.Parse(item.Content as string);

                        if(value > sqftMax)
                        {
                            item.Visibility = Visibility.Collapsed;
                        }
                    }
                }
            }
            if (sqftMin == -1 && sqftMax == -1)
            {
                sizeSet = false;
            }
            else
            {
                sizeSet = true;
            }
            applyMoreFiltersLabelText();
            Search(sender, e);
        }


        private void UseExactMatchChecked(object sender, RoutedEventArgs e)
        {
            BedOne.Content = "1";
            BedTwo.Content = "2";
            BedThree.Content = "3";
            BedFour.Content = "4";
            BedFive.Content = "5";

            numBedMax = numBedMin; // For updating value right on click rather than having to reclick
            applyBedBathLabelText();
            Search(sender, e);
        }

        private void UseExactMatchUnchecked(object sender, RoutedEventArgs e)
        {
            BedOne.Content = "1+";
            BedTwo.Content = "2+";
            BedThree.Content = "3+";
            BedFour.Content = "4+";
            BedFive.Content = "5+";

            numBedMax = -1; // For updating value right on click rather than having to reclick
            applyBedBathLabelText();
            Search(sender, e);
        }

        private void applyBedBathLabelText()
        {
            if (BedBathLabel == null)
            {
                return;
            }
            if (numBedMin <= 0 && numBathMin <= 0)
            {
                BedBathLabel.Text = "Beds & Baths";
                return;
            } 
            BedBathLabel.Text = "";

            BedBathLabel.Text += Math.Max(0, numBedMin);
            if (numBedMax == -1)
            {
                BedBathLabel.Text += "+";
            }
            BedBathLabel.Text += " bd, ";

            BedBathLabel.Text += Math.Max(0, numBathMin);
            if (numBathMax == -1)
            {
                BedBathLabel.Text += "+";
            }
            BedBathLabel.Text += " ba";
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

            } else if (rb.Content.ToString().Equals("1"))
            {
                numBedMin = 1;
                numBedMax = 1;

            }
            else if (rb.Content.ToString().Equals("2"))
            {
                numBedMin = 2;
                numBedMax = 2;

            }
            else if (rb.Content.ToString().Equals("3"))
            {
                numBedMin = 3;
                numBedMax = 3;

            }
            else if (rb.Content.ToString().Equals("4"))
            {
                numBedMin = 4;
                numBedMax = 4;

            }
            else if (rb.Content.ToString().Equals("5"))
            {
                numBedMin = 5;
                numBedMax = 5;
            }
            applyBedBathLabelText();
            Search(sender, e);
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
            applyBedBathLabelText();
            Search(sender, e);
        }

        private void applyHomeTypeLabelText()
        {
            if (homeTypes.Count == 0)
            {
                HomeTypeLabel.Text = "Home Type";
                return;
            }
            HomeTypeLabel.Text = "";
            foreach (HomeType h in homeTypes)
            {
                HomeTypeLabel.Text += h.ToString();
                HomeTypeLabel.Text += ", ";
            }
            HomeTypeLabel.Text = HomeTypeLabel.Text.Substring(0, HomeTypeLabel.Text.Length - 2); // remove trailing comma
            if (HomeTypeLabel.Text.Length > 15)
            {
                HomeTypeLabel.Text = HomeTypeLabel.Text.Substring(0, 15) + "...";
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
            applyHomeTypeLabelText();
            Search(sender, e);
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
            applyHomeTypeLabelText();
            Search(sender, e);
        }


        private void AmenitiesChecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if(cb.Name == "Parking" && cb.IsChecked == true)
            {
                parking = true;
            }

            if (cb.Name == "WasherDryer" && cb.IsChecked == true)
            {
                washerDryer = true;
            }

            if (parking)
            {
                parkingSet = true;
            } else
            {
                parkingSet = false;
            }

            if (washerDryer)
            {
                washerDryerSet = true;
            } else
            {
                washerDryerSet = false;
            }
            applyMoreFiltersLabelText();
            Search(sender, e);
        }

        private void YearTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string year = string.Empty;
            if(tb.Text != "Min" && tb.Text != "Max" && tb.Text != "")
            {
                foreach(char c in tb.Text)
                {
                    if (Char.IsDigit(c))
                    {
                        year += c;
                    }
                }
                tb.Text = year;
                
                if(tb.Name == "MinYear")
                {
                    yearBuiltMin = Int32.Parse(year);
                } else
                {
                    yearBuiltMax = Int32.Parse(year);
                }
            } else {
                if (tb.Name == "MinYear")
                {
                    yearBuiltMin = -1;
                }
                else
                {
                    yearBuiltMax = -1;
                }

            }
        }

        private void AgeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string age = string.Empty;
            if (tb.Text != "—")
            {
                foreach (char c in tb.Text)
                {
                    if (Char.IsDigit(c))
                    {
                        age += c;
                    }
                }
                tb.Text = age;
            }
            if (age.Length > 0)
            {
                maxAgeSet = true;
            } else
            {
                maxAgeSet = false;
            }
            Search(sender, e);
            applyMoreFiltersLabelText();
        }

        private void AmenitiesUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Name == "Parking" && cb.IsChecked == false)
            {
                parking = false;
            }

            if (cb.Name == "WasherDryer" && cb.IsChecked == false)
            {
                washerDryer = false;
            }
            if (parking)
            {
                parkingSet = true;
            }
            else
            {
                parkingSet = false;
            }

            if (washerDryer)
            {
                washerDryerSet = true;
            }
            else
            {
                washerDryerSet = false;
            }
            applyMoreFiltersLabelText();
            Search(sender, e);
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
            Search(sender, e);
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = "";
            box.GotFocus -= TextBox_GotFocus;
            box.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        // If the user deselects textbox and leaves it blank, display default message
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "Enter your city or neighborhood";
                box.GotFocus += TextBox_GotFocus;
                box.Foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85));
            }
        }
        private void YearMinMax_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = "";
            box.GotFocus -= YearMinMax_GotFocus;
        }

        // If the user deselects textbox and leaves it blank, display default message
        private void YearMinMax_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = box.Name.Equals("MinYear") ? "Min" : "Max";
                box.GotFocus += YearMinMax_GotFocus;
            }

            if ((MinYear != null && MinYear.Text.Length > 0 && !MinYear.Text.ToUpper().Equals("MIN")) || (MaxYear != null && MaxYear.Text.Length > 0 && !MaxYear.Text.ToUpper().Equals("MAX")))
            {
                yearBuiltFilterSet = true;
            }
            else
            {
                yearBuiltFilterSet = false;
            }
            applyMoreFiltersLabelText();
            Search(sender, e);
        }
        
        private void ChooseMinPriceInput(object sender, MouseButtonEventArgs e)
        {
            priceMin = Int32.Parse((sender as TextBlock).Tag as string);
            PriceMinInput.Text = (sender as TextBlock).Text;
            MaxPriceOptions.Visibility = Visibility.Visible;
            applyPriceInputLabelText();
            Search(sender, e);
        }

        private void ChooseMaxPriceInput(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            if (tb.Tag.Equals("Max"))
            {
                priceMax = -1;
                PriceMaxInput.Text = "Max";
            }
            else
            {
                priceMax = Int32.Parse(tb.Tag as string);
                PriceMaxInput.Text = (sender as TextBlock).Text;
            }
            applyPriceInputLabelText();
            Search(sender, e);

        }

        private void Age_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = "";
            box.GotFocus -= Age_GotFocus;
        }

        private void Age_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = "—";
                box.GotFocus += TextBox_GotFocus;
                box.Foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85));
            }
        }
    }

}
