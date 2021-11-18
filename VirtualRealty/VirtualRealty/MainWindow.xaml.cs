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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Listing> Listings;
        public List<SmallListing> SmallListings;

        public static SavedSearches savedSearchesPage;

        public MainWindow()
        {
            InitializeComponent();
            Listings = CreateListings();
            SmallListings = CreateSmallListings(Listings);
            CreateInitialSavedSearches();

            Switcher.pageSwitcher = this;
            Switcher.Switch(new ListingsPage());  //initial page   
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }


        /*
         * Method used to create disgusting list of Listings
         */
        private List<Listing> CreateListings()
        {
            //TODO
            return new List<Listing>();
        }

        /*
         * Take a list of Listings and create the small listing for each one
         */
        private List<SmallListing> CreateSmallListings(List<Listing> Listings)
        {
            List<SmallListing> vals = new List<SmallListing>();
            foreach (Listing l in Listings)
            {
                SmallListing L = new SmallListing();
                L.SetListing(l);
                vals.Add(L);
            }
            return vals;
        }

        private void CreateInitialSavedSearches()
        {
            SavedSearches.savedSearches = new List<SavedSearch>();

            SavedSearch savedSearch1 = new SavedSearch
            {
                SearchName = "Condos in Calgary",
                LocationSearchString = "Calgary",
                HomeType = new List<HomeType>
            {
                HomeType.Condo,
                HomeType.Apartment
            },
                MinPrice = 100000,
                MaxPrice = 500000,
                MinSqFt = 500,
                MaxSqFt = 1200,
                LastAccessed = DateTime.Parse("10/6/2021"),
                DateSaved = DateTime.Parse("10/3/2021")
            };

            SavedSearches.savedSearches.Add(savedSearch1);

            SavedSearch savedSearch2 = new SavedSearch
            {
                SearchName = "Mansions",
                LocationSearchString = "Airdrie",
                HomeType = new List<HomeType>
            {
                HomeType.House,
            },
                MinPrice = 5000000,
                MinSqFt = 3000,
                MaxSqFt = 10000,
                MinBeds = 5,
                MinBaths = 4,
                LastAccessed = DateTime.Parse("6/10/2021"),
                DateSaved = DateTime.Parse("3/10/2021")
            };

            SavedSearches.savedSearches.Add(savedSearch2);
        }
    }
}
