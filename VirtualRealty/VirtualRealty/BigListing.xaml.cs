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

        private void OpenGallery(object sender, RoutedEventArgs e)
        {
           // ContactPopup contactPopup = new ContactPopup();
           // contactPopup.SetContactInfo(Listing.Address);
           // BigListingGrid.Children.Add(contactPopup);
           //ListingGallery gallery = new ListingGallery

        }


        //public void SetThumbnailImages(int i)
        //{
        //    string src = "/img/" + i.ToString() + ".jpg";
        //
        //    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
        //    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
        //    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
        //
        //}

        public void SetThumbnailImages(int i)
        {
            string src;
            string addr = Listing.Address;


            switch (addr)
            {
                case "1510-1001 13th Ave SW #1510, Calgary, AB T2R 0K7":
                    src = "/img/" + (0).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "4328 W 4th St NW #202, Calgary, AB T2K 1A2":
                    src = "/img/" + (1).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "180 S Prestwick Acres Ln SE, Calgary, AB T2Z 3Y2":
                    src = "/img/" + (2).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "136 NE Edelweiss Dr NW, Calgary, AB T3A 3P6":
                    src = "/img/" + (3).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "9 S Hamptons Vw NW, Calgary, AB T3A 6M1":
                    src = "/img/" + (4).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "711 Bearspaw Village Dr, Rocky View County, AB T3L 2P3":
                    src = "/img/" + (5).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "6503 SE Ranchview Dr NW #25, Calgary, AB T3G 1P2":
                    src = "/img/" + (6).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "448-8535 Bonaventure Dr SE #448, Calgary, AB T2H 2R7":
                    src = "/img/" + (7).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "7638 W 27th St SE, Calgary, AB T2C 1E7":
                    src = "/img/" + (8).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "841 NE Royal Ave SW, Calgary, AB T2T 0L4":
                    src = "/img/" + (9).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "272 Cornerstone Pass NE, Calgary, AB T3N 1G3":
                    src = "/img/" + (10).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "3228 E Rae Cres SE, Calgary, AB T2A 1Y3":
                    src = "/img/" + (11).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "128 S Pinetree Rd NE, Calgary, AB T1Y 1K2":
                    src = "/img/" + (12).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "55 E Falconer Ter NE, Calgary, AB T3J 1W3":
                    src = "/img/" + (13).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "58 E Skyview Point Rise NE, Calgary, AB T3N 0G9":
                    src = "/img/" + (14).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "15 Grier Pl NE, Calgary, AB T2K 5Y5":
                    src = "/img/" + (15).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "Varsity Place Apartments, # 773175, 3607 49th St NW, Calgary, AB T3A 2H3":
                    src = "/img/" + (16).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "1240 N 18a St NW, Calgary, AB T2N 2H4":
                    src = "/img/" + (17).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "915 44th St SE, Calgary, AB T2A 5K7":
                    src = "/img/" + (18).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "Pineridge Apartments, # 772706, 433 Pinestream Pl NE, Calgary, AB T1Y 3A5":
                    src = "/img/" + (19).ToString() + ".jpg";
                    this.LargeImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage1.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    this.SmallImage2.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;

            }


        }
    }
}
