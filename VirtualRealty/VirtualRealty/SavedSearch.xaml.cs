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
                homeType = value;

                string homeTypeStr = "";
                foreach (HomeType homeType in value)
                {
                    homeTypeStr += homeType;
                    homeTypeStr += ", ";
                }
                homeTypeStr = homeTypeStr.Substring(0, homeTypeStr.Length - 2);
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = homeTypeStr,
                };
                Left.Children.Add(label);
            }
        }
        // TODO (Oscar): add support for millions?
        private int minPrice;
        public int MinPrice {
            get { return minPrice; }
            set {
                minPrice = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "$" + string.Format("{0:#.00}", Convert.ToDecimal(minPrice) / 1000) + "k+"
                };
                Left.Children.Add(label);
            }
        }
        // THIS ASSUMES YOU SET MAXPRICE RIGHT AFTER MINPRICE!!!
        private int maxPrice;
        public int MaxPrice {
            get { return maxPrice; }
            set
            {
                maxPrice = value;
                if (this.minPrice != 0)
                {
                    Left.Children.RemoveAt(Left.Children.Count - 1); // Remove the last one which was like $minprice+

                }
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "$" + string.Format("{0:#.00}", Convert.ToDecimal(minPrice) / 1000) + "k - $" + string.Format("{0:#.00}", Convert.ToDecimal(maxPrice) / 1000) + "k"
                };
                Left.Children.Add(label);
            }
        }
        private int minSqFt;
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
        private int maxSqFt;
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
        private int minBeds;
        public int MinBeds {
            get { return minBeds;  }
            set
            {
                minBeds = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "" + minBeds + "+ Beds"
                };
                Center.Children.Add(label);
            }
        }
        // THIS ASSUMES YOU SET MAXBEDS RIGHT AFTER MINBEDS!!!
        private int maxBeds;
        public int MaxBeds {
            get { return maxBeds;  }
            set
            {
                maxBeds = value;
                if (this.minBeds != 0)
                {
                    Center.Children.RemoveAt(Center.Children.Count - 1); // Remove the last one which was like "2+ beds"
                }
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "" + minBeds + " Beds" // We use exact match if there's a max
                };
                Center.Children.Add(label);
            }
        }

        private float minBaths;
        public float MinBaths {
            get { return minBaths;  }
            set {
                minBaths = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "" + minBaths  + "+ Baths"
                };
                Center.Children.Add(label);
            }
        }
        // THIS ASSUMES YOU SET MAXBATHS RIGHT AFTER MAXBATHS!!!
        private float maxBaths;
        public float MaxBaths
        {
            get { return maxBaths; }
            set
            {
                maxBaths = value;
                if (this.minBaths != 0)
                {
                    Center.Children.RemoveAt(Center.Children.Count - 1); // Remove the last one which was like "2+ baths"
                }
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "" + minBaths + " Baths" // We use exact match if there's a max for baths
                };
                Center.Children.Add(label);
            }
        }
        private bool hasGarage;
        public bool HasGarage {
            get { return hasGarage; }
            set
            {
                hasGarage = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "Has Garage"
                };
                Center.Children.Add(label);
            }
        }

        // Goes on right
        private int maxAgeOfListingInDays;
        public int MaxAgeOfListingInDays
        {
            get { return maxAgeOfListingInDays; }
            set
            {
                maxAgeOfListingInDays = value;
                Label label = new Label
                {
                    FontSize = LABEL_FONTSIZE,
                    Content = "Listing is at most " + maxAgeOfListingInDays + "days old"
                };
                Right.Children.Add(label);
            }
        }
        private int minYearBuilt;
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
        private int maxYearBuilt;
        public int MaxYearBuilt {
            get { return maxYearBuilt; }
            set {
                maxYearBuilt = value;
                if (minYearBuilt != 0)
                {
                    Right.Children.RemoveAt(Center.Children.Count - 1); // Remove the last one which was like "2005-2021"
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
            // TODO (Oscar): max beds and baths
            MainWindow.LP.SetListings(Listing.FilterListings(MainWindow.Listings, PriceMin:MinPrice, PriceMax:MaxPrice, /* HomeTypes:HomeTypes */ MinBeds:MinBeds, MinBaths:MinBaths, MinSize:MinSqFt, MaxSize:MaxSqFt, MaxListingAge:MaxAgeOfListingInDays, MinYear:MinYearBuilt, MaxYear:MaxYearBuilt, Washer:hasWasherDryer, Parking:hasGarage ? "Garage" : ""));
            Switcher.Switch(MainWindow.LP);
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
