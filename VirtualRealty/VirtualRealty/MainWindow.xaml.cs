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

        public static ListingsPage LP = new ListingsPage();
        public static SavedSearches savedSearchesPage;
        public static MapView MapViewPage = new MapView();
        public static Favorites FavouritesPage = new Favorites();
        public static FavoritesMapView FavouritesMapViewPage = new FavoritesMapView();

        public MainWindow()
        {
            CreateInitialSavedSearches();
            savedSearchesPage = new SavedSearches();

            Listings = CreateListings();

            // ORIGINAL ----------------------------------------
            ListingsPage LP = new ListingsPage();
            Listings.Sort(new ListingComparer(ListingComparer.SortBy.DateListed));
            LP.SetListings(Listing.FilterListings(Listings));

            InitializeComponent();

            Switcher.pageSwitcher = this;
            Switcher.Switch(LP);  //initial page 
            // ORIGINAL ----------------------------------------


            // ADDED -------------------------------------------
            //BigListing BL = new BigListing();
            //BL.SetBigListing(Listings[2]);

            //LP.SetListings(Listings);

            //InitializeComponent();

            //Switcher.pageSwitcher = this;
            //Switcher.Switch(BL);  //initial page 
            // ADDED -------------------------------------------

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
            ToReturn.Add(new Listing(true, 1050000, "1510-1001 13th Ave SW #1510, Calgary, AB T2R 0K7", DateTime.Parse("2021-11-15"), 3, 2, 3583, HomeType.House, "Stunning like new Penthouse unit priced to sell! Over 2500 sqft of luxury living in the Beltline, walk to work in the core and to all the attractions of17th Avenue. The sellers have done a complete renovation including gutting the kitchen and tearing down walls, this is truly an open concept livingspace. Gorgeous new island with marble counter tops, new cabinets and appliances. Hardwood throughout. Media room that could be 4th bedroomif you wanted. Raised sitting area, the perfect place for pre-dinner cocktails and admiring the views. Master ensuite was just finished and includessuch fine, thought out details as back lit mirrors, deep stand alone soaker tub, massive walk in shower and make up console around the corneraway from the steam. 2 large balconies for BBQ and relaxing in the fresh air with views of the Calgary Tower and to the South. 2 titled parkingstalls. Lots of storage.", false, "Underground", true, 1981, "Park", true, true, true, true, true, new List<string>()));
            ToReturn.Add(new Listing(true, 840000, "4328 W 4th St NW #202, Calgary, AB T2K 1A2", DateTime.Parse("2021-11-15"), 1, 1, 2730, HomeType.Apartment, "Judicial sale! Large 1 bedroom condo located Highland Park. Good sized kitchen and dining area. Living room is bright, east facing towards the park. Bedroom is generously sized with plenty of closet space. Private patio with no neighbours behind. Fantastic location close to many amenities including Tim's, 7-Eleven, a variety of dining options, shopping, and public transit. Short distance to downtown! It is vary rare to get a home at this price with an oversized single garage. It also  has a great big side yard! Super quick and easy access to Crowchild Trail and Shaganappi Trail. Lots of upgrades. 9' ceilings. Hardwood & tile cover the floors. Upgraded appliances & lighting fixtures, extended height cabinets. An ideal mud room is situated off the kitchen and is fully equipped with customized built-ins and a laundry room. The master RETREAT located on the main floor, includes a 2-way FIREPLACE.", false, "Off-Street", false, 1986, "None", true, false, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 270000, "180 S Prestwick Acres Ln SE, Calgary, AB T2Z 3Y2", DateTime.Parse("2021-11-15"), 2, 2, 1063, HomeType.House, "Welcome to this Superb and very well maintained townhome with a location you will love at the Mosiac in McKenzie Towne! Easy access to all your shopping needs, parks, schools, playgrounds, open spaces and a friendly active neighbourhood! Be the first to enjoy the BRAND NEW LUXURY VINYL PLANK flooring that is incredibly durable which will make your life easier and enhance any look or style you choose to decorate with as these beautiful warm light tones give you endless options! Also BRAND NEW is all the amazing soft and luxurious carpet on the stairs heading to the upper level and throughout the upper floor! Not only has all the flooring been replaced this entire home has just been Professionally Painted with a beautiful designer colour! Features you will also see in this home are the desirable open floor plan, 2 piece bath on main level, well functioning kitchen with Maple Cabinetry and clean appliances.", false, "Garage", false, 2001, "None", true, false, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 1600000, "136 NE Edelweiss Dr NW, Calgary, AB T3A 3P6", DateTime.Parse("2021-11-02"), 5, 5, 3059, HomeType.Condo, "This spectacular Estate home is truly one to view, as if you're not already sold on the stunning, snow-capped, sweeping mountain views, the location or the neighbourhood, it’s likely the interior & layout that will put you over the edge. Completely re-designed from the studs, this 5 bedroom, 4.5 bathroom family home is truly set to impress the most discerning of buyers. As the amazing curb appeal brings you in, you will instantly feel a sense that this home is right for you & your family. The back-drop views from all 3 levels is truly something to see, showcasing a sprawling main floor w/ grand entryway, massive entertainment-gourmet kitchen & island, family room, main floor office, informal + semi-formal dining areas & family room that leads you to your private, covered patio, overlooking Calgary’s most stunning views. Main floor, fully redesigned laundry/custom mudroom + 2pc powder room complete the main.", false, "Garage", false, 1985, "Stunning", true, true, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 1690000, "9 S Hamptons Vw NW, Calgary, AB T3A 6M1", DateTime.Parse("2021-10-14"), 5, 5, 4530, HomeType.House, "Welcome to the exclusive gated community of VIA ULTIMA Hamptons, an enclave of 10 extra ordinary homes built by the award-winning builder Calbridge Homes. Perched above the Hamptons Golf Course with spectacular majestic views of the fairways and ponds, this 5-bedroom, 2 storey, with triple attached garage, boasts over 6,300 sq ft of luxury living space. Grand open design highlighted by the impressive great room with soaring 20 ft ceilings inundating the home with natural light. The grand chef’s kitchen is truly the heart of the home, perfect for entertaining and social gatherings, it will satisfy the most discerning chef. It is equipped with high-end stainless steel appliances including Sub Zero fridge/freezer, Miele dishwasher, Viking cooktop, double wall oven with warming drawer, maple cabinets, granite counters, island, breakfast bar, 2 extra large pantries and bright eating area with deck access!", false, "Garage", false, 2007, "Lakeview", true, true, false, true, false, new List<string>()));
            ToReturn.Add(new Listing(true, 5400000, "711 Bearspaw Village Dr, Rocky View County, AB T3L 2P3", DateTime.Parse("2021-05-08"), 5, 6, 5566, HomeType.House, "A RARE opportunity to own this luxurious CUSTOM-BUILT executive country estate minutes from Calgary.  Welcome to 711 Bearspaw Village Drive. This MAGNIFICENT walk-out perched high atop the BOW VALLEY corridor provides an incredible combination of outstanding features, exceptional construction and EXTENSIVE, meticulous landscaping featuring numerous ponds and waterfalls.  This home is a blend of PRIVATE, TRANQUIL yet rugged beauty set in amongst a forest of trees and Rocky Mountain backdrop. With over 8300 sq' of LUXURY and understated ELEGANCE there is no shortage of special areas in this home. The great room with SOARING 30' ceilings provides a wonderful area to take in mother nature, the FLOOR TO CEILING fireplace with rock surround adds to the warmth of this AWE-INSPIRING room. The master RETREAT located on the main floor, includes a 2-way FIREPLACE, lounge area surrounded by windows.", false, "Garage", false, 2001, "Stunning", true, true, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 234900, "6503 SE Ranchview Dr NW #25, Calgary, AB T3G 1P2", DateTime.Parse("2021-10-01"), 3, 2, 999, HomeType.Townhouse, "BACKING ON TO AN OFF-LEASH DOG PARK, this MOVE-IN READY, 3 bedroom/2 bath townhouse is waiting for its new OWNER!  This unit has newer carpet on main level, upper level and stairways, newer linoleum in both bathrooms, and natural pine wood floors in kitchen and hallway. Main floor has an open kitchen with plenty of cabinets, NEW COUNTERTOPS, new stainless steel stove and dishwasher.  Wood-burning fireplace in the living room will keep you cozy all winter long.  The 2nd floor has a master bedroom with walk-in closet.  Two additional bedrooms and a 4 piece bath complete the upper level.  Basement is fully developed w/huge family room, games/rec room, laundry room & 3 piece bath.  Extra insulation in attic to keep you warm in the winter and cooler in the summer. Unit also has newer vinyl windows, front door, screen door and patio doors. Roof and eaves were replaced in 2008 and the exterior painted in 2016.", false, "Parking Lot", false, 1978, "None", true, false, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 330000, "448-8535 Bonaventure Dr SE #448, Calgary, AB T2H 2R7", DateTime.Parse("2021-10-25"), 1, 2, 1001, HomeType.Condo, "Welcome to this beautiful top floor unit in Sierra's of Heritage. This well maintained space is flooded with natural light coming  from a wall of west facing windows.  You can enjoy a  spectacular mountain view from  the living room , as well as the master bedroom and your large covered balcony will wow you with both mountain and downtown views. The moment you step through the doors you will appreciate the 9 foot ceilings that make this open space feel even more grand. Functional layout of an open kitchen, dining room and living space will be great for entertaining, as well as cozying up around your gas fireplace. Beautiful french doors lead you to the large den area that can serve as a home office, spare bedroom or a hobby room.  The master bedroom is oversized and can easily fit a king size bed. Ensuite bathroom provides tons of space and a walk-in closet is large and fitted with shelves already.", false, "None", false, 2000, "Innercity", false, false, true, false, true, new List<string>()));
            ToReturn.Add(new Listing(true, 249000, "7638 W 27th St SE, Calgary, AB T2C 1E7", DateTime.Parse("2021-09-28"), 4, 1, 920, HomeType.Townhouse, "Great potential! This home was renovated a few years ago. Parts of the home seem tired but with a little bit of love this place could shine again! It has 3 bedrooms in the upstairs and one bedroom downstairs that can be used as a bedroom (you may want to put a windows in it), the kitchen has been updated and the living room is spacious where you can spend lots of time with your friends and family! It is vary rare to get a home at this price with an oversized single garage. It also  has a great big side yard! There are tenants living in the home and they would be happy to stay living there. This home is also close to where the new green line will be coming through - so you will get access to rapid transit to downtown! Come take a look! An ideal mud room is situated off the kitchen and is fully equipped with customized built-ins and a laundry room. The master bedroom is oversized and can easily fit a king size bed.", false, "Garage", false, 1971, "None", true, false, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 2095000, "841 NE Royal Ave SW, Calgary, AB T2T 0L4", DateTime.Parse("2021-11-16"), 3, 4, 3370, HomeType.House, "This remarkable brick and sandstone residence was built for Reuben Rupert Jamieson, Calgary's Mayor (1908-1910) in 1912 & is situated on a private 11,051 sq. ft. lot in prestigious Mount Royal. With over 4,608 sq. ft of developed living space on 4 levels, this charming family home has been completely renovated preserving the original character of the home while providing all of the modern conveniences. The gracious front veranda lures you in & opens up to the large foyer & all of the formal living spaces throughout featuring onsite finished Brazilian cherry finished hardwood floors, an expansive living room with a gas fireplace surrounded in contemporary tile & coffered ceilings with hidden lighting, elegant French doors open to the formal dining area with ample room to host a multitude of special occasions. The updated, gourmet kitchen with  maple cabinets, quartz counter tops, stainless steel appliances.", false, "Garage", false, 1912, "Downtown", true, true, false, true, false, new List<string>()));
            ToReturn.Add(new Listing(true, 459000, "272 Cornerstone Pass NE, Calgary, AB T3N 1G3", DateTime.Parse("2021-04-20"), 3, 3, 1497, HomeType.Townhouse, "Almost like new, beautiful Open Concept Home in the Desirable Community of Cornerstone.  The House features great size living space on the main, a big dining space and kitchen to the rear of the home with big windows. Kitchen Counter space is huge.  Upstairs features Master bedroom with 4PC en-suite bath and 2 other big size bedrooms and another 4 PC bath.  Laundry is upstairs. SEPARATE ENTRANCE for the undeveloped basement.  2 min Walk to park and playground. 5 min drive to huge commercial plaza with banks, groceries, restaurants etc. Showcasing superb finishing & detailing this family home provides over 5,400 sq ft of developed living space featuring functionality & practicality.The Brazilian cherry hardwood floors take you through an open floor plan boasting a front den highlighted by curved glass french doors, formal dining room and a sprawling living room with a linear stone gas fireplace and french doors.", false, "Parking Lot", false, 2017, "None", true, false, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 334900, "3228 E Rae Cres SE, Calgary, AB T2A 1Y3", DateTime.Parse("2021-11-03"), 3, 2, 1003, HomeType.House, "Tucked away on this quiet crescent in Radisson Heights is this charming one owner home, within minutes to neighbourhood schools, parks & International Avenue. Fully finished 1960's bungalow with 3 bedrooms & hardwood floors, sunny eat-in oak kitchen & fenced West backyard with gardens & oversized single detached garage. Great family-friendly floorplan featuring inviting living room with hardwood floors & built-in bookcases, with wonderful kitchen with pantry & black/white appliances including cooktop stove & built-in convection oven. Hardwood floors in the 3 main floor bedrooms & the full bath has been beautifully updated with tile floors, walk-in shower & vessel sink. Lower level is finished with office & craft room, 2 piece bath, rumpus room with bar & workshop/laundry/storage area. Backyard with brick patio & retractable awning is the perfect spot to relax & enjoy the outdoors, trees & plenty of gardening space.", false, "Garage", false, 1966, "None", true, false, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 435000, "128 S Pinetree Rd NE, Calgary, AB T1Y 1K2", DateTime.Parse("2021-10-22"), 5, 3, 1449, HomeType.House, "Perfect for the first home owner or investment property located on the quiet street of Pineridge. This completely renovated in the last few years home features open style Bungalow on large lot with RV pad,  oversized double detached garage. Kitchen features granite countertops, stainless steel appliances, living and dining rooms, 3 bedrooms, the master bedroom comes complete with 2 pc ensuite. Fully finished 2 bedrooms illegal suite in basement with separate entrance, share laundry room and newer hot water tank. A must see ! Book your appointment today. 2 kitchens one being the spicy kitchen. A Flex room & an extended breakfast nook. Lots of upgrades. 9' ceilings. Hardwood & tile cover the floors. 3rd loft level features an additional bonus room, bedroom & 4pc bath. An ideal mud room is situated off the kitchen and is fully equipped with customized built-ins and a laundry room.", false, "Garage", false, 1974, "None", true, false, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(true, 235000, "55 E Falconer Ter NE, Calgary, AB T3J 1W3", DateTime.Parse("2021-09-18"), 3, 2, 1112, HomeType.Townhouse, "Welcome to 55 Falconer Terrace! This one is truly a hidden gem with pride of ownership throughout the home. As you come in the front entrance you are greeting by rich, warm hardwood floors. The living room is bathed in natural light and invites you to relax after a hard days work. The kitchen is beautiful with updated cabinets with wine rack, countertops, new taps, glass backsplash and top of the line SS appliances. An updated half bath completes the floor. Head upstairs and you will find 3 bedrooms with a really nice sized primary bedroom and another updated 4pc bath. Head out to your West facing, fenced backyard to enjoy your private oasis. You can imagine enjoying a glass of wine and watching the sun set.  Updates include – hardwood floors (main), porcelain floors (kitchen & ½ bath), door hardware, low flow toilets, 2 x screen doors for air flow, fence painted (2021). As well complex updates include – windows, roof, downspouts & eaves.", false, "Parking Lot", false, 1980, "None", true, false, false, false, false, new List<string>()));
            Listing firstExistingFave = new Listing(true, 829900, "58 E Skyview Point Rise NE, Calgary, AB T3N 0G9", DateTime.Parse("2021-11-01"), 7, 7, 3212, HomeType.House, "Spectacular well maintained home! 5 above grade beds, each has their own bathroom plus 2 beds legal basement suite w/ walk up entrance. This home offers a total of 4,099 sqft living space including the basement! If you have a large family, THIS IS FOR YOU! A THREE STOREY home with a total of 3 kitchens! You can live up and rent down. Main floor boasts an open concept layout w/ a large island kitchen w/walk thru pantry & GRANITE counters. 2 kitchens one being the spicy kitchen. A Flex room & an extended breakfast nook. Lots of upgrades. 9' ceilings. Hardwood & tile cover the floors. Upgraded appliances & lighting fixtures, extended height cabinets. 2nd level offers 4 beds, a bonus room & upper laundry. 3rd loft level features an additional bonus room, bedroom & 4pc bath. The basement is legal & has 2 beds, 4pc bath. It has its own kitchen, washer & dryer & separate entrance. This home is backing on to a walkpath with green space.", true, "garage", false, 2013, "None", true, true, false, false, false, new List<string>());
            firstExistingFave.DateFavourited = DateTime.Parse("2021-11-20");
            ToReturn.Add(firstExistingFave);
            ToReturn.Add(new Listing(false, 1369, "15 Grier Pl NE, Calgary, AB T2K 5Y5", DateTime.Parse("2021-04-13"), 1, 1, 876, HomeType.Apartment, "Message us about our move-in bonuses, which include gift cards!* Steps away from a wide variety of restaurants, retail stores, and parklands. Close by City of Calgary Toboggan Hill, Walmart, Canadian Tire, McCall Lake Golf Course, Rona, and more. Convenient access to McKnight Blvd NE, Deerfoot Trail, and Calgary International Airport. Occupancy for the unfurnished 1-bed and 2-bed units. Water & heat included. Included modern appliances: fridge, microwave, stove, dishwasher, and range hood. Parking available for rent. Staged photos are for illustrative purposes only. Suite finishes and layouts may vary by availability. Do you have a vacant unit? Inquire us about our cost-effective tenant placement solutions for landlords and realtors in Ontario! An ideal mud room is situated off the kitchen and is fully equipped with customized built-ins and a laundry room.  *Terms & conditions apply.", false, "None", false, 1980, "None", true, true, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(false, 1365, "Varsity Place Apartments, # 773175, 3607 49th St NW, Calgary, AB T3A 2H3", DateTime.Parse("2021-11-15"), 2, 1, 840, HomeType.Apartment, "Rent today and save up to 2 months on rent with the most exclusive rates on TELUS Optik TV and High-Speed Internet. Live your life uninterrupted at Varsity Place Apartments where you come first! Students receive a $300 move in bonus! Virtual Showings Available! Location, location, location! Varsity Place Apartments is conveniently located next to Market Mall and the University of Calgary. Super quick and easy access to Crowchild Trail and Shaganappi Trail. With green spaces, parks, and playgrounds, enjoy plenty of outdoor living. WORRY-FREE LIVING -24-hour customer service team -On-site cleaning staff-On-site landscaping and snow removal-On-call emergency maintenance-On-site security and video surveillance WHAT SETS US APART-$399 security deposit -Community involvement opportunities-Exclusive discounts with local businesses*. 1 and 2 bedroom suites-Standard and upgraded suites.", false, "Parking Lot", true, 2001, "Downtown", true, true, false, false, true, new List<string>()));
            ToReturn.Add(new Listing(false, 5500, "1240 N 18a St NW, Calgary, AB T2N 2H4", DateTime.Parse("2021-09-05"), 5, 4.5, 3777, HomeType.House, "A stunning corner lot location in Briar Hill/Hounsfield Heights sits this impressive home. Showcasing superb finishing & detailing this family home provides over 5,400 sq ft of developed living space featuring functionality & practicality.The Brazilian cherry hardwood floors take you through an open floor plan boasting a front den highlighted by curved glass french doors, formal dining room and a sprawling living room with a linear stone gas fireplace and french doors that extend out to the patio retreat.   A timeless kitchen will bring out your inner chef, providing you with an ideal space to prepare and entertain. The area features a grand centre island, quartz countertops, dual dishwasher, dual wall ovens, induction cook top, breakfast nook & walk-in butlers style pantry. An ideal mud room is situated off the kitchen and is fully equipped with customized built-ins and a laundry room. Look below for more details.", false, "Garage", true, 2005, "None", true, true, false, false, false, new List<string>()));
            ToReturn.Add(new Listing(false, 1019, "915 44th St SE, Calgary, AB T2A 5K7", DateTime.Parse("2021-02-27"), 1, 1, 522, HomeType.Apartment, "Message us about our move-in bonuses, which include 1 month free rent on a 13 month lease!* Steps away from a wide variety of restaurants, retail stores, and parklands. Close by Marlborough Mall, Bob Bahan Aquatic & Fitness Centre, Elliston Park, TransCanada Centre, Southview Center, Forest Lawn Library, shops on International Avenue, and more. Convenient access to Deerfoot Trail, Stoney Trail, 17 Ave SE, 16 Ave NE, and Calgary International Airport.  Occupancy for the unfurnished 1-bed units. Water, hydro & heat included. Included appliances: fridge, stove, and range hood. Parking available for rent. Staged photos are for illustrative purposes only. Suite finishes and layouts may vary by availability.  Do you have a vacant unit? Inquire us about our cost-effective tenant placement solutions for landlords and realtors in Ontario! Ensuite bathroom provides tons of space and a walk-in closet is large and fitted with shelves already.", false, "Parking Lot", true, 1993, "None", true, false, false, false, false, new List<string>()));
            Listing secondExistingFave = new Listing(false, 1000, "Pineridge Apartments, # 772706, 433 Pinestream Pl NE, Calgary, AB T1Y 3A5", DateTime.Parse("2021-11-17"), 1, 1, 625, HomeType.Apartment, "Rent today and save up to 2 months on rent with the most exclusive rates on TELUS Optik TV and High-Speed Internet. Live your life uninterrupted at Pineridge Apartments where you come first! Virtual Showings Available! Location, location, location! Pineridge Apartments is conveniently located next Village Square Leisure Centre and Pinecliff Park. Super quick and easy access to transit and Deerfoot Trail. With green spaces, parks, and playgrounds, enjoy plenty of outdoor living. WORRY-FREE LIVING -24-hour customer service team -On-site cleaning staff-On-site landscaping and snow removal-On-call emergency maintenance-On-site security and video surveillance WHAT SETS US APART-$399 security deposit -Community involvement opportunities-Exclusive discounts with local businesses*-Free resident events- Referral program LIVE HERE-Functional 1 ,2 and 3 bedroom suites-Standard. ", true, "Underground", true, 1999, "None", true, true, false, true, true, new List<string>());
            secondExistingFave.DateFavourited = DateTime.Parse("2021-11-15");
            ToReturn.Add(secondExistingFave);

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
