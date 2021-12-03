
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace VirtualRealty
{

    public class Listing
    {
        public readonly bool Purchase, Heating, AC, Pool, Gym, Elevator;
        public bool IsFavourited { get; set; }
        public DateTime DateFavourited;
        public bool Washer;
        public string Parking;
        public readonly string Address, Description, View;
        public HomeType ListingType;
        public readonly int Price, Beds, YearBuilt, size; //size is square footage
        public readonly double Baths;
        public double Latitude, Longitude;
        public readonly DateTime DateListed;
        public List<string> Images { get; set; } //list of paths to images for this listing
        public SmallListing Small;
        //public BigListing Big; //Wait for Matthew's branch

        public Listing()
        {
            //generic contructor, should not be used
            DateListed = DateTime.Now;

            //BigListing Big = new BigListing();
            //Big.SetBigListing(this);

            Small = new SmallListing();
            Small.SetListing(this);
            //Small.SetBigListingInfo(Big);
        }

        private async void CalcLocation()
        {
            //Location to use as a hint in geocoding
            BasicGeoposition CalgaryPos = new BasicGeoposition() { Latitude = 51, Longitude = -114 };
            Geopoint Calgary = new Geopoint(CalgaryPos);

            MapService.ServiceToken = "n4SwISsG3bGTljC5Z3Tk~l-OwVP9iSAx6EqO1HMyhdQ~AiCExZh0kbW6ciH98aJZRKb_TW58Kyponu3JazAS-GhveBQ2ZmuwNgr6YmMP1760";


            MapLocationFinderResult Result = await MapLocationFinder.FindLocationsAsync(this.Address, Calgary);

            
            System.Diagnostics.Debug.WriteLine("Now calculating location for address " + this.Address);

            while (true)
            {
                if (Result.Status == MapLocationFinderStatus.Success && Result.Locations.Count > 0) break;

                Result = await MapLocationFinder.FindLocationsAsync(this.Address, Calgary);
            }

            int a = Result.Locations.Count;

            this.Latitude = Result.Locations[0].Point.Position.Latitude;
            this.Longitude = Result.Locations[0].Point.Position.Longitude;

            System.Diagnostics.Debug.WriteLine("Finished calculating location for address " + this.Address);
        
        }

        public Listing(bool Purchase, int Price, string Address, DateTime ListingDate, int Bed, double Bath, int Size, HomeType Type,
            string Description, bool Favourited, string Parking, bool Washer, int Year, string View, bool Heating, bool AC,
            bool Pool, bool Gym, bool Elevator, List<String> Images)
        {
            this.Purchase = Purchase;
            this.Price = Price;
            //string[] Parts = Address.Split('#');
            //System.Diagnostics.Debug.WriteLine(Parts[0]);
            this.Address = Address;
            this.DateListed = ListingDate;
            this.Beds = Bed;
            this.Baths = Bath;
            this.size = Size;
            this.ListingType = Type;
            this.Description = Description;
            this.IsFavourited = Favourited;
            this.Parking = Parking;
            this.Washer = Washer;
            this.YearBuilt = Year;
            this.View = View;
            this.Heating = Heating;
            this.AC = AC;
            this.Pool = Pool;
            this.Gym = Gym;
            this.Elevator = Elevator;
            this.Images = Images;

            CalcLocation();


            Small = new SmallListing();
            Small.SetListing(this);
            //Small.SetBigListingInfo(Big);
        }

        public bool ToggleFavourite()
        {
            return IsFavourited = !IsFavourited;
        }

        public void AddImage(string NewImage)
        {
            Images.Add(NewImage);
        }

        public void AddImages(List<string> NewImages)
        {
            foreach (string Image in NewImages)
            {
                Images.Add(Image);
            }
        }



        /*
         * Massive headache to filer listings.
         * All filter arguments are optional, meaning you only need to include the filters you want.
         *  ex FilterListings(SomeList,PriceMax:30000,MinSize:500)
         * This means you can also call this function in sequence with one filter each time
         * to filter by multiple filters (although it will be slow).
         */
        public static List<Listing> FilterListings(List<Listing> Listings, int PriceMin = -1, int PriceMax = -1, List<HomeType> Types = null,
            int MinBeds = -1, int MaxBeds = -1, double MinBaths = -1, double MaxBaths = -1, int MinSize = -1, int MaxSize = -1, int MaxListingAge = -1,
            int MinYear = -1, int MaxYear = -1, bool Washer = false, bool Parking = false, bool Purchase = true, bool Favourite = false)
        {
            List<Listing> ToReturn = new List<Listing>();

            foreach (Listing L in Listings){

                //each if checks if that filter matters, and then if this filter matches
                if (PriceMin >= 0 && L.Price < PriceMin)
                {
                    continue;
                }
                if (PriceMax >= 0 && L.Price > PriceMax)
                {
                        continue;
                }; 
                if (Types != null && Types.Count > 0 && !Types.Contains(L.ListingType))
                {
                    continue;
                }; 
                if (MinBeds >= 0 && L.Beds < MinBeds)
                {
                    continue;
                }; 
                if (MaxBeds >= 0 && L.Beds > MaxBeds)
                {
                    continue;
                }; 
                if (MinBaths >= 0 && L.Baths < MinBaths)
                {
                    continue;
                }; 
                if (MaxBaths >= 0 && L.Baths > MaxBaths)
                {
                    continue;
                }; 
                if (MinSize >= 0 && L.size < MinSize)
                {
                    continue;
                }; 
                if (MaxSize >= 0 && L.size > MaxSize)
                {
                    continue;
                }; 
                if (MaxListingAge >= 0 && (DateTime.Today - L.DateListed).Days > MaxListingAge)
                {
                    continue;
                }; 
                if (MinYear >= 0 && L.YearBuilt < MinYear)
                {
                    continue;
                }; 
                if (MaxYear >= 0 && L.YearBuilt > MaxYear)
                {
                    continue;
                }; 

                //simple substring check for washer and parking
                if (Washer && !L.Washer)
                {
                    continue;
                }; 
                if (Parking && (L.Parking.Equals("None") || L.Parking.Length <= 0))
                {
                    continue;
                }; 
                if (!Purchase && L.Purchase)
                {
                    continue;
                }; 
                if (Purchase && !L.Purchase)
                {
                    continue;
                }; 
                if (Favourite && !L.IsFavourited)
                {
                    continue;
                };

                //this Listing passes all of the filters
                Listing newListing = new Listing(L.Purchase, L.Price, L.Address, L.DateListed, L.Beds, L.Baths, L.size, L.ListingType, L.Description, L.IsFavourited, L.Parking, L.Washer, L.YearBuilt, L.View, L.Heating, L.AC, L.Pool, L.Gym, L.Elevator, L.Images);
                if (L.DateFavourited != null)
                {
                    newListing.DateFavourited = L.DateFavourited;
                }
                ToReturn.Add(newListing);
            }

            return ToReturn;
        }

    }

    /* A class to allow easy comparing and sorting of Listings
     * 
     * Create an instance of this class with the desired Order, and whether 
     * the result is ascending or descending.  Then pass that object as an argument
     * into array.sort()
     */
    class ListingComparer : IComparer<Listing>
    {

        Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.BasicGeoposition Loc;

        public enum SortBy
        { 
            Price,
            DateListed,
            AgeOfBuilding,
            DateFavourited,
            Proximity,
        }

        public bool Descending = false;
        public SortBy Order;

        public ListingComparer(SortBy Order)
        {
            this.Order = Order;
        }

        public void SetLocation(Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.BasicGeoposition L)
        {
            Loc = L;
        }

        public ListingComparer(SortBy Order, bool Descending)
        {
            this.Order = Order;
            this.Descending = Descending;
        }
    
        
        public int Compare(Listing A, Listing B)
        {

            int invert;
            if (Descending) invert = 1;
            else invert = -1;

            switch (Order)
            {
                case SortBy.Price:
                    return invert * A.Price.CompareTo(B.Price);
                case SortBy.DateListed:
                    return invert * A.DateListed.CompareTo(B.DateListed);
                case SortBy.AgeOfBuilding:
                    return invert * A.YearBuilt.CompareTo(B.YearBuilt);
                case SortBy.DateFavourited: // Date favorited can be null so be careful
                    return invert * A.DateFavourited.CompareTo(B.DateFavourited);
                case SortBy.Proximity:
                    return (int) (invert * (Math.Sqrt(Math.Pow((Loc.Latitude - A.Latitude), 2) + Math.Pow(Loc.Longitude - A.Longitude, 2) - Math.Sqrt(Math.Pow(Loc.Latitude - B.Latitude, 2) + Math.Pow(Loc.Longitude - B.Longitude, 2)))));
                default:
                    return 0;
            }
        }
    }


}
