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
        public bool IsFavourited;
        public readonly string Address, ListingType, Description, Parking, View, Washer;
        public readonly int Price, Beds, Baths, YearBuilt, size; //size is square footage
        public readonly DateTime DateListed;
        public List<string> Images; //list of paths to images for this listing

        public Listing()
        {
            //generic contructor, should not be used
            DateListed = DateTime.Now;
        }

        public Listing(bool Purchase,int Price, string Address, DateTime ListingDate,int Bed, int Bath, int Size, string Type, string Description, bool Favourited, string Parking, string Washer,int Year, string View, bool Heating, bool AC,bool Pool, bool Gym, bool elevator,string[] Images)
        {
            //do stuff with this massive list of arguments
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
}
