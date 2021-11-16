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
                SearchTitle.Content = SearchName;
                searchName = value;
            }
        }
        public string LocationSearchString { get; set; }
        public List<HomeType> HomeType { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int MinSqFt { get; set; }
        public int MaxSqFt { get; set; }
        public int MinBeds { get; set; }
        public int MaxBeds { get; set; }
        public float MinBaths { get; set; }
        public float MaxBaths { get; set; }
        public bool HasGarage { get; set; }
        public bool HasWasherDryer { get; set; }
        public int MaxAgeOfListingInDays { get; set; }
        public int MinYearBuilt { get; set; }
        public int MaxYearBuilt { get; set; }
        public DateTime LastAccessed { get; set; }
        public DateTime DateSaved { get; set; }

        public SavedSearch()
        {
            InitializeComponent();

            if (LocationSearchString != null)
            {
                Location.Content = LocationSearchString;
            }
            if (this.HomeType != null)
            {
                string homeTypeStr = "";
                foreach (HomeType homeType in this.HomeType)
                {
                    homeTypeStr += homeType;
                    homeTypeStr += ", ";
                }
                homeTypeStr = homeTypeStr.Substring(0, homeTypeStr.Length - 2);
                Label label = new Label();
                label.Content = homeTypeStr;
                Left.Children.Add(label);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
