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

            SavedSearch savedSearch1 = new SavedSearch();
            savedSearch1.SearchName = "Condos in Calgary";
            savedSearch1.LocationSearchString = "Calgary";
            savedSearch1.HomeType = new List<HomeType>
            {
                HomeType.Condo,
            };
            savedSearch1.MinPrice = 100000;
            savedSearch1.MaxPrice = 500000;
            savedSearch1.MinSqFt = 500;
            savedSearch1.MaxSqFt = 1200;
            savedSearch1.LastAccessed = DateTime.Parse("6/10/2021");
            savedSearch1.DateSaved = DateTime.Parse("3/10/2021");

            SavedSearches.savedSearches.Add(savedSearch1);

            SavedSearch savedSearch2 = new SavedSearch();
            savedSearch2.SearchName = "Mansions";
            savedSearch2.LocationSearchString = "Airdrie";
            savedSearch2.HomeType = new List<HomeType>
            {
                HomeType.House,
            };
            savedSearch2.MinPrice = 5000000;
            savedSearch2.MaxPrice = 9999000;
            savedSearch2.MinSqFt = 3000;
            savedSearch2.MaxSqFt = 10000;
            savedSearch2.MinBeds = 5;
            savedSearch2.MinBaths = 5;
            savedSearch2.LastAccessed = DateTime.Parse("6/10/2021");
            savedSearch2.DateSaved = DateTime.Parse("3/10/2021");

            SavedSearches.savedSearches.Add(savedSearch2);
        }
    }
}
