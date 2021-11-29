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
    /// Interaction logic for SmallListing.xaml
    /// </summary>
    public partial class SmallListing : UserControl
    {

        private Listing Listing;
        private List<Listing> ListingsList;
        //private BigListing bigListing;
        private Grid ListingPgGrid;
        private int index;

        public SmallListing()
        {
            InitializeComponent();
        }

        public void SetListing(Listing L)
        {
            Listing = L;

            this.Price.Content = "$" + String.Format("{0:n0}", Listing.Price);
            this.Address.Content = Listing.Address;
            this.Type.Content = L.ListingType.ToString();
            this.BedBath.Content = Listing.Beds.ToString() + " Beds, " + Listing.Baths.ToString() + " Baths";
            this.Size.Content = Listing.size.ToString() + " sqft";
        }

        //public void SetBigListingInfo(BigListing l)
        //{
        //    bigListing = l;
        //}

        public void SetListingGrid(Grid grid)
        {
            ListingPgGrid = grid;
        }

        public void SetListingInd(List<Listing> list, int i)
        {
            ListingsList = list;
            index = i;
        }

        private void OpenBigListing(object sender, MouseButtonEventArgs e)
        {

            //if(ListingPgGrid.Children.Contains(bigListing))
            //{
            //    ListingPgGrid.Children.Remove(bigListing);
            //}

            //ListingPgGrid.Children.Add(bigListing);

            // need to remove children
            BigListing bigL = new BigListing();
            bigL.SetBigListingInd(ListingsList, index);
            bigL.SetBigListing(Listing);
            ListingPgGrid.Children.Add(bigL);

        }

    }
}
