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

        // TODO (Oscar): change out adding labels to just having existing ones so I can control the font size and spacing better?

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
                    Content = "" + minSqFt + "+ sqft"
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
                    Content = "" + minSqFt + " - " + maxSqFt + "sqft"
                };
                Left.Children.Add(label);
            }
        }

        // Goes on center
        public int MinBeds { get; set; }
        public int MaxBeds { get; set; }
        public float MinBaths { get; set; }
        public float MaxBaths { get; set; }
        public bool HasGarage { get; set; }

        // Goes on right
        public bool HasWasherDryer { get; set; }
        public int MaxAgeOfListingInDays { get; set; }
        public int MinYearBuilt { get; set; }
        public int MaxYearBuilt { get; set; }

        public DateTime LastAccessed { get; set; }
        public DateTime DateSaved { get; set; }

        public SavedSearch()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
