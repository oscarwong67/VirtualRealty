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
        private List<Listing> ListingsList;
        private int prev, next;
        public BigListing()
        {
            InitializeComponent();
        }


        public void SetBigListing(Listing L)
        {
            Listing = L;

            // If the prev index is below 0 don't show back btn
            if (prev < 0)
            {
                this.BackBtn.Visibility = Visibility.Collapsed;
            }
            // If the next index is greater than listings size don't show next btn
            if (next >= ListingsList.Count)
            {
                this.NextBtn.Visibility = Visibility.Collapsed;
            }


            this.Price.Content = "$" + String.Format("{0:n0}", Listing.Price);
            this.Address.Content = Listing.Address;

            //this.Price.Content = ListingsList.IndexOf(L) + " ";
            //int temp = ListingsList.IndexOf(Listing) - 1;
            //int temp2 = ListingsList.IndexOf(Listing) + 1;
            //this.Address.Content = "Prev: " + temp + "Next:" + temp2 + "Ind: " + ListingsList.IndexOf(L);

            // Convert date to amount of days passed since post
            // Might need to handle case if listing date is in the future (date posted would be negative)
            int days = (DateTime.Now - Listing.DateListed).Days;
            this.Date.Content = "Posted " + days.ToString() + " day(s) ago";

            // Fill Beed, Bath, sqft, Home type
            this.ListingDetails.Content = Listing.Beds.ToString() + " Beds | "
                + Listing.Baths.ToString() + " Baths | "
                + Listing.size.ToString() + " sqft | "
                + Listing.ListingType;

            // listing description
            this.Description.Text = Listing.Description;

            // listing details
            this.Parking.Content = Listing.Parking;
            this.Washer.Content = Listing.Washer;
            this.Year.Content = Listing.YearBuilt.ToString();
            this.View.Content = Listing.View;

            // If the listing has a feature set it to yes, else no
            this.Heating.Content = Listing.Heating ? "Yes" : "No";
            this.Washer.Content = Listing.Washer ? "Yes" : "No";
            this.Cooling.Content = Listing.AC ? "Yes" : "No";
            this.Pool.Content = Listing.Pool ? "Yes" : "No";
            this.Gym.Content = Listing.Gym ? "Yes" : "No";
            this.Elevator.Content = Listing.Elevator ? "Yes" : "No";
        }

        public void SetBigListingInd(List<Listing> list, int i)
        {
            // set list of listings
            ListingsList = list;

            // set next, and prev for navigation between listings
            prev = i-1;
            next = i+1;
        }
        
        private void CloseBigListing(object sender, RoutedEventArgs e)
        {
            // Close the big listing popup using the close button, or if the user clicked outside the popup
            this.Visibility = Visibility.Collapsed;
            this.BigListingGrid.Children.Clear();
            MainWindow.MapViewPage.MapViewer.Visibility = Visibility.Visible;
        }

        // Opens the contact page popup
        private void OpenContactPopup(object sender, RoutedEventArgs e)
        {
            ContactPopup contactPopup = new ContactPopup();
            contactPopup.SetContactInfo(Listing.Address);
            BigListingGrid.Children.Add(contactPopup);
        }

        private void BigListingBack(object sender, RoutedEventArgs e)
        {

            if (prev >= 0)
            {
                SetBigListing(ListingsList[prev]);
                SetThumbnailImages(prev);
                prev--;
                next--;
                if(prev < 0)
                {
                    this.BackBtn.Visibility = Visibility.Collapsed;
                }
                if(next <= ListingsList.Count)
                {
                    this.NextBtn.Visibility = Visibility.Visible;
                }
            }
        }

        private void BigListingNext(object sender, RoutedEventArgs e)
        {
            if(next < ListingsList.Count && next >= 0)
            {
                SetBigListing(ListingsList[next]);
                SetThumbnailImages(next);
                next++;
                prev++;
                if (prev >= 0)
                {
                    this.BackBtn.Visibility = Visibility.Visible;
                }
                if(next >= ListingsList.Count)
                {
                    this.NextBtn.Visibility = Visibility.Collapsed;
                }
            }
        }

        public void SetThumbnailImages(int i)
        {
            string src = "/img/" + i.ToString() + ".jpg";

            this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
            this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
            this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
        }


        private void OpenGallery(object sender, RoutedEventArgs e)
        {
           // ContactPopup contactPopup = new ContactPopup();
           // contactPopup.SetContactInfo(Listing.Address);
           // BigListingGrid.Children.Add(contactPopup);
           //ListingGallery gallery = new ListingGallery

        }
    }
}
