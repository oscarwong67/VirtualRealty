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

            ListingsPage LP = new ListingsPage();
            LP.SetListings(SmallListings);

            Switcher.pageSwitcher = this;
            Switcher.Switch(LP);  //initial page   
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
            List<Listing> ToReturn =  new List<Listing> ();
            ToReturn.Add(new Listing(true, 1050000, "1510 - 1001 13th Ave SW #1510, Calgary, AB T2R 0K7", DateTime.Parse("2021-11-15"), 3, 2, 2583, "Condo", "Stunning like new Penthouse unit priced to sell! Over 2500 sqft of luxury living in the Beltline, walk to work in the core and to all the attractions of17th Avenue. The sellers have done a complete renovation including gutting the kitchen and tearing down walls, this is truly an open concept livingspace. Gorgeous new island with marble counter tops, new cabinets and appliances. Hardwood throughout. Media room that could be 4th bedroomif you wanted. Raised sitting area, the perfect place for pre-dinner cocktails and admiring the views. Master ensuite was just finished and includessuch fine, thought out details as back lit mirrors, deep stand alone soaker tub, massive walk in shower and make up console around the corneraway from the steam. 2 large balconies for BBQ and relaxing in the fresh air with views of the Calgary Tower and to the South. 2 titled parkingstalls. Lots of storage.", false, "Underground", "In-Unit", 1981, "Park", true, true, true, true, true,new List<string>()));
            ToReturn.Add(new Listing(true, 84000, "4328 W 4th St NW #202, Calgary, AB T2K 1A2", DateTime.Parse("2021-11-15"), 1, 1, 473, "Appartment", "Judicial sale! Large 1 bedroom condo located Highland Park. Good sized kitchen and dining area. Living room is bright, east facing towards the park. Bedroom is generously sized with plenty of closet space. Private patio with no neighbours behind. Fantastic location close to many amenities including Tim's, 7-Eleven, a variety of dining options, shopping, and public transit. Short distance to downtown!", false, "Off-Street", "N/A", 1986, "None", true, false, false, false, false, new List<string>()));
            return ToReturn;
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
