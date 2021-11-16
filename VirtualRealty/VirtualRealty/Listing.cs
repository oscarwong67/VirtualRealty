using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualRealty
{

    class Listing
    {
        public readonly bool Purchase, Heating, AC, Pool, Gym, Elevator;
        public bool IsFavourited { get; set; }
        public readonly string Address, ListingType, Description, Parking, View, Washer;
        public readonly int Price, Beds, Baths, YearBuilt, size; //size is square footage
        public readonly DateTime DateListed;
        public List<string> Images { get; set; } //list of paths to images for this listing

        public Listing()
        {
            //generic contructor, should not be used
            DateListed = DateTime.Now;
        }

        public Listing(bool Purchase, int Price, string Address, DateTime ListingDate, int Bed, int Bath, int Size, string Type,
            string Description, bool Favourited, string Parking, string Washer, int Year, string View, bool Heating, bool AC,
            bool Pool, bool Gym, bool Elevator, List<String> Images)
        {
            this.Purchase = Purchase;
            this.Price = Price;
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

    }

    /* A class to allow easy comparing and sorting of Listings
     * 
     * Create an instance of this class with the desired Order, and whether 
     * the result is ascending or descending.  Then pass that object as an argument
     * into array.sort()
     */
    class ListingComparer : IComparer<Listing>
    {
        public enum SortBy
        { 
            Price,
            DateListed,
            AgeOfBuilding,
            Proximity
        }

        public bool Descending = false;
        public SortBy Order;

        public ListingComparer(SortBy Order)
        {
            this.Order = Order;
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
                case SortBy.Proximity:
                    //TODO
                    return 0;
                default:
                    return 0;
            }
        }
    }


}
