using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirtualRealty
{
    /// <summary>
    /// Interaction logic for SavedSearch.xaml
    /// </summary>
    public partial class SavedSearch : UserControl
    {
        private string searchName;
        public string SearchName {
            get { return searchName; }
            set {
                SearchTitle.Content = value;
                searchName = value;
            }
        }

        private string locationSearchString;
        public string LocationSearchString {
            get { return locationSearchString;  }
            set {
                Location.Content = value;
                locationSearchString = value;
            }
        }

        private static int LABEL_FONTSIZE = 14;

        // Goes on left
        private List<HomeType> homeType;
        public List<HomeType> HomeType {
            get { return homeType; }
            set {
                if (value == null || value.Count() == 0)
                {
                    return;
                }
                homeType = value;

                string homeTypeStr = "";
                foreach (HomeType homeType in value)
                {
                    homeTypeStr += homeType;
                    homeTypeStr += ", ";
                }
                homeTypeStr = homeTypeStr.Substring(0, homeTypeStr.Length - 2);
                HomeTypeLabel.Content = homeTypeStr;
            }
        }
        // TODO (Oscar): add support for millions?
        private int minPrice = -1;
        public int MinPrice {
            get { return minPrice; }
            set {
                minPrice = value;
                PriceLabel.Content = "$" + string.Format("{0:#.00}", Convert.ToDecimal(minPrice) / 1000) + "k+";
            }
        }
        // THIS ASSUMES YOU SET MAXPRICE RIGHT AFTER MINPRICE!!!
        private int maxPrice = -1;
        public int MaxPrice {
            get { return maxPrice; }
            set
            {
                maxPrice = value;
                PriceLabel.Content = "$" + string.Format("{0:#.00}", Convert.ToDecimal(minPrice) / 1000) + "k - $" + string.Format("{0:#.00}", Convert.ToDecimal(maxPrice) / 1000) + "k";
                if (maxPrice == minPrice)
                {
                    PriceLabel.Content = "$" + string.Format("{0:#.00}", Convert.ToDecimal(minPrice) / 1000) + "k";
                }
            }
        }
        private int minSqFt = -1;
        public int MinSqFt {
            get { return minSqFt; }
            set {
                minSqFt = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "" + minSqFt + "+ sq. ft"
                };
                Left.Children.Add(label);
            }
        }
        // THIS ASSUMES YOU SET MAXSQFT RIGHT AFTER MINSQFT!!!
        private int maxSqFt = -1;
        public int MaxSqFt {
            get { return maxSqFt; }
            set
            {
                maxSqFt = value;
                if (this.minSqFt != 0)
                {
                    Left.Children.RemoveAt(Left.Children.Count - 1); // Remove the last one which was like "1000+ sqft"
                }
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "" + minSqFt + " - " + maxSqFt + "sq. ft"
                };
                Left.Children.Add(label);
            }
        }

        // Goes on center
        private int minBeds = -1;
        public int MinBeds {
            get { return minBeds;  }
            set
            {
                minBeds = value;
                BedsLabel.Content = "" + minBeds + "+ Beds";
            }
        }
        // THIS ASSUMES YOU SET MAXBEDS RIGHT AFTER MINBEDS!!!
        private int maxBeds = -1;
        public int MaxBeds {
            get { return maxBeds;  }
            set
            {
                maxBeds = value;
                BedsLabel.Content = "" + minBeds + " Beds"; // We use exact match if there's a max
            }
        }

        private double minBaths = -1;
        public double MinBaths {
            get { return minBaths;  }
            set {
                minBaths = value;
                BathsLabel.Content = "" + minBaths + "+ Baths";
            }
        }
        // THIS ASSUMES YOU SET MAXBATHS RIGHT AFTER MAXBATHS!!!
        private double maxBaths = -1;
        public double MaxBaths
        {
            get { return maxBaths; }
            set
            {
                maxBaths = value;
                BathsLabel.Content = "" + minBaths + "+ Baths";
            }
        }
        private bool hasParking;
        public bool HasParking {
            get { return hasParking; }
            set
            {
                hasParking = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "Has Parking"
                };
                Center.Children.Add(label);
            }
        }

        // Goes on right
        private int maxAgeOfListingInDays = -1;
        public int MaxAgeOfListingInDays
        {
            get { return maxAgeOfListingInDays; }
            set
            {
                maxAgeOfListingInDays = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "Listing is at most " + maxAgeOfListingInDays + " days old"
                };
                Right.Children.Add(label);
            }
        }
        private int minYearBuilt = -1;
        public int MinYearBuilt {
            get { return minYearBuilt; }
            set
            {
                minYearBuilt = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "Built in " + minYearBuilt + " - 2021"
                };
                Right.Children.Add(label);
            }
        }
        // THIS ASSUMES YOU SET MaxYearBuilt RIGHT AFTER MinYearBuilt!!!
        private int maxYearBuilt = -1;
        public int MaxYearBuilt {
            get { return maxYearBuilt; }
            set {
                maxYearBuilt = value;
                if (minYearBuilt != 0)
                {
                    Right.Children.RemoveAt(Right.Children.Count - 1); // Remove the last one which was like "2005-2021"
                }
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "Built in " + minYearBuilt + " - " + maxYearBuilt
                };
                Right.Children.Add(label);
            }
        }
        private bool hasWasherDryer;
        public bool HasWasherDryer {
            get { return hasWasherDryer; }
            set
            {
                hasWasherDryer = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "Has Washer & Dryer"
                };
                Right.Children.Add(label);
            }
        }
        // TODO (Oscar): if we have time, add parking as a filter

        // NEVER SET LOCATION AFTER PURCHASE!!!!!
        private bool isPurchase = true;
        public bool IsPurchase
        {
            get { return isPurchase; }
            set
            {
                isPurchase = value;
                if (value == false)
                {
                    Content = Location.Content + ", Rentals";
                } else
                {
                    Content = Location.Content + ", Purchases";
                }
            }
        }

        private DateTime lastAccessed;
        public DateTime LastAccessed {
            get { return lastAccessed; }
            set {
                lastAccessed = value;
                LastAccessedSection.Content = "Last Accessed: " + lastAccessed.ToLongDateString();
            }
        }

        private DateTime dateSaved;
        public DateTime DateSaved {
            get { return dateSaved; }
            set
            {
                dateSaved = value;
                DateSavedSection.Content = "Date Saved: " + dateSaved.ToLongDateString();
            }
        }

        public SavedSearch()
        {
            InitializeComponent();
            maxAgeOfListingInDays = -1;
            maxYearBuilt = -1;
        }

        private void ApplyThisSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.LP.SetListings(Listing.FilterListings(MainWindow.Listings, PriceMin:MinPrice, PriceMax:MaxPrice, Types:HomeType, MinBeds:MinBeds, MaxBeds:MaxBeds, MinBaths:MinBaths, MaxBaths:MaxBaths, MinSize:MinSqFt, MaxSize:MaxSqFt, MaxListingAge:MaxAgeOfListingInDays, MinYear:MinYearBuilt, MaxYear:MaxYearBuilt, Washer:hasWasherDryer, Parking:hasParking, Purchase:isPurchase));
            Switcher.Switch(MainWindow.LP);
        }

        private void DeleteThisSearch_Click(object sender, RoutedEventArgs e)
        {
            UIElement target = this;
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the search " + SearchTitle.Content + "?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                // Yes code here  
                MainWindow.savedSearchesPage.SavedSearchesSection.Children.Remove(target);
                SavedSearches.savedSearches.Remove(target as SavedSearch);
            }
        }
    }

    class SavedSearchComparer : IComparer<SavedSearch>
    {
        public enum SortBy
        {
            DateSavedNewest,
            DateSavedOldest,
            LastAccessed,
        }
        
        public SortBy Order;

        public SavedSearchComparer(SortBy Order)
        {
            this.Order = Order;
        }

        public int Compare (SavedSearch a, SavedSearch b)
        {
            switch (Order)
            {
                case SortBy.DateSavedNewest:
                    return -1 * a.DateSaved.CompareTo(b.DateSaved);
                case SortBy.DateSavedOldest:
                    return a.DateSaved.CompareTo(b.DateSaved);
                case SortBy.LastAccessed:
                    return -1 * a.LastAccessed.CompareTo(b.LastAccessed);
                default:
                    return 0;
            }
        }
    }
}
