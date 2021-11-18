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

        public static List<Listing> Listings;

        public static SavedSearches savedSearchesPage;

        public MainWindow()
        {
            Listings = CreateListings();

            ListingsPage LP = new ListingsPage();
            LP.SetListings(Listings);

            InitializeComponent();
            
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
            ToReturn.Add(new Listing(true, 84000, "4328 W 4th St NW #202, Calgary, AB T2K 1A2", DateTime.Parse("2021-11-15"), 1, 1, 473, "Apartment", "Judicial sale! Large 1 bedroom condo located Highland Park. Good sized kitchen and dining area. Living room is bright, east facing towards the park. Bedroom is generously sized with plenty of closet space. Private patio with no neighbours behind. Fantastic location close to many amenities including Tim's, 7-Eleven, a variety of dining options, shopping, and public transit. Short distance to downtown!", false, "Off-Street", "N/A", 1986, "None", true, false, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 330000, "448-8535 Bonaventure Dr SE #448, Calgary, AB T2H 2R7", DateTime.Parse("2021-10-25"), 1, 2, 1001, "Condo", "Welcome to this beautiful top floor unit in Sierra's of Heritage. This well maintained space is flooded with natural light coming  from a wall of west facing windows.  You can enjoy a  spectacular mountain view from  the living room , as well as the master bedroom and your large covered balcony will wow you with both mountain and downtown views. The moment you step through the doors you will appreciate the 9 foot ceilings that make this open space feel even more grand. Functional layout of an open kitchen, dining room and living space will be great for entertaining, as well as cozying up around your gas fireplace. Beautiful french doors lead you to the large den area that can serve as a home office, spare bedroom or a hobby room.  The master bedroom is oversized and can easily fit a king size bed. Ensuite bathroom provides tons of space and a walk-in closet is large and fitted with shelves already.  This unit has an additional 3 piece bathroom and a laundry/storage room.  You will find 2 parking stalls that are assigned to this unit to be conveniently located  near the elevators. This well managed , 29+ adult building is quiet and hosts tons of amenities like swimming pool, hot tub and workout room to keep you fit and moving.   Games room, billiard space,  library and a large well equipped workshop will make sure you continue  with your hobbies.  Guest suits,  banquet hall with a kitchen allows you to host your family and stay social.  Many spaces in this building, like craft and media room or games room  to meet like minded people and new friend.   Lets not forget about the location of this condominium - close to all the shopping centers, medical clinics, hospital, malls, coffee shops and restaurants.", false, "None", "None", 2000, "Innercity", false, false, true, false, true, new List<string>()));
            return ToReturn;
        }

        public static void CreateInitialSavedSearches()
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
                MaxSqFt = 2000,
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
