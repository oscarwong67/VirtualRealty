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

            this.Price.Content = "$" + String.Format("{0:n0}", Listing.Price);
            this.Address.Content = Listing.Address;

            // Convert date to amount of days passed since post
            // Might need to handle case if listing date is in the future (date posted would be negative)
            int days = (DateTime.Now - Listing.DateListed).Days;
            this.Date.Content = "Posted " + days.ToString() + " day(s) ago";

            // Fill Beed, Bath, sqft, Home type
            this.ListingDetails.Content = Listing.Beds.ToString() + " Beds | "
                + Listing.Baths.ToString() + " Baths | "
                + Listing.size.ToString() + " sqft | "
                + Listing.ListingType;

            this.Description.Text = Listing.Description;

            
            this.Parking.Content = Listing.Parking;
            this.Washer.Content = Listing.Washer;
            this.Year.Content = Listing.YearBuilt.ToString();
            this.View.Content = Listing.View;

            // If the listing has a feature set it to yes, else no
            this.Heating.Content = Listing.Heating ? "Yes" : "No";
            this.Cooling.Content = Listing.AC ? "Yes" : "No";
            this.Pool.Content = Listing.Pool ? "Yes" : "No";
            this.Gym.Content = Listing.Gym ? "Yes" : "No";
            this.Elevator.Content = Listing.Elevator ? "Yes" : "No";
        }

        /*
        public readonly bool Purchase, Heating, AC, Pool, Gym, Elevator;
        public bool IsFavourited { get; set; }
        public readonly string Address, ListingType, Description, Parking, View, Washer;
        */

        private void CloseBigListing(object sender, RoutedEventArgs e)
        {
            // Close the big listing popup using the close button, or if the user clicked outside the popup
            this.Visibility = Visibility.Collapsed;
        }

        // Opens the contact page popup
        private void OpenContactPopup(object sender, RoutedEventArgs e)
        {
            ContactPopup contactPopup = new ContactPopup();
            contactPopup.SetContactInfo(Listing.Address);
            BigListingGrid.Children.Add(contactPopup);
        }
    }
}
