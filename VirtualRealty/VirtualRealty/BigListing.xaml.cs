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
    /// Interaction logic for BigListing.xaml
    /// </summary>
    public partial class BigListing : UserControl
    {
        private Listing Listing;
        public BigListing()
        {
            InitializeComponent();
        }

        public void SetBigListing(Listing L)
        {
            Listing = L;

            this.Price.Content = "$" + Listing.Price.ToString();
            this.Address.Content = Listing.Address;
            this.Date.Content = Listing.DateListed.ToString();
            this.Bed.Content = Listing.Beds.ToString() + " Bed | ";
            this.Bath.Content = Listing.Baths.ToString() + " Bath | ";
            this.SqFt.Content = Listing.size.ToString() + " sqft | ";
            this.HomeType.Content = Listing.ListingType;
            this.Description.Text = Listing.Description;
            /*
            this.Parking.Content = Listing.Parking;
            this.Washer.Content = Listing.Washer;
            this.Year.Content = Listing.YearBuilt.ToString();
            this.View.Content = Listing.View;
            // might need if statements
            this.Heating.Content = Listing.Heating.ToString();
            this.Cooling.Content = Listing.AC.ToString();
            this.Pool.Content = Listing.Pool.ToString();
            this.Elevator.Content = Listing.Elevator.ToString();*/
        }
    }
}
