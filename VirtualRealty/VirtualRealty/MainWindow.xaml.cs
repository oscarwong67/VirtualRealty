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
    }
}
