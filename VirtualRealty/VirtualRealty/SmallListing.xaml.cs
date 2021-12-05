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
            SetDisplayImage(L);
        }

        public void ShowPurchaseOrRental()
        {
            string purchaseOrRentText = this.Listing.Purchase ? "Sale" : "Rent";
            this.Type.Content = this.Listing.ListingType.ToString() + ", For " + purchaseOrRentText;
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
            bigL.SetThumbnailImages();
            bigL.SetMapImage();

            ListingPgGrid.Children.Add(bigL);

            MainWindow.MapViewPage.MapViewer.Visibility = Visibility.Hidden;
            MainWindow.FavouritesMapViewPage.MapViewer2.Visibility = Visibility.Hidden;

            // Set images here
        }


        public void SetDisplayImage(Listing L)
        {
            // change source of image to corresponding index
            //string src = "/img/" + name + ".jpg";
            string src;
            string addr = L.Address;

            //this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
            switch (addr)
            {
                case "1510-1001 13th Ave SW #1510, Calgary, AB T2R 0K7":
                    src = "/img/" + (0).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "4328 W 4th St NW #202, Calgary, AB T2K 1A2":
                    src = "/img/" + (1).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "180 S Prestwick Acres Ln SE, Calgary, AB T2Z 3Y2":
                    src = "/img/" + (2).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "136 NE Edelweiss Dr NW, Calgary, AB T3A 3P6":
                    src = "/img/" + (3).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "9 S Hamptons Vw NW, Calgary, AB T3A 6M1":
                    src = "/img/" + (4).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "711 Bearspaw Village Dr, Rocky View County, AB T3L 2P3":
                    src = "/img/" + (5).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "6503 SE Ranchview Dr NW #25, Calgary, AB T3G 1P2":
                    src = "/img/" + (6).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "448-8535 Bonaventure Dr SE #448, Calgary, AB T2H 2R7":
                    src = "/img/" + (7).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "7638 W 27th St SE, Calgary, AB T2C 1E7":
                    src = "/img/" + (8).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "841 NE Royal Ave SW, Calgary, AB T2T 0L4":
                    src = "/img/" + (9).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "272 Cornerstone Pass NE, Calgary, AB T3N 1G3":
                    src = "/img/" + (10).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "3228 E Rae Cres SE, Calgary, AB T2A 1Y3":
                    src = "/img/" + (11).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "128 S Pinetree Rd NE, Calgary, AB T1Y 1K2":
                    src = "/img/" + (12).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "55 E Falconer Ter NE, Calgary, AB T3J 1W3":
                    src = "/img/" + (13).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "58 E Skyview Point Rise NE, Calgary, AB T3N 0G9":
                    src = "/img/" + (14).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "15 Grier Pl NE, Calgary, AB T2K 5Y5":
                    src = "/img/" + (15).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "Varsity Place Apartments, # 773175, 3607 49th St NW, Calgary, AB T3A 2H3":
                    src = "/img/" + (16).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "1240 N 18a St NW, Calgary, AB T2N 2H4":
                    src = "/img/" + (17).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "915 44th St SE, Calgary, AB T2A 5K7":
                    src = "/img/" + (18).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;
                case "Pineridge Apartments, # 772706, 433 Pinestream Pl NE, Calgary, AB T1Y 3A5":
                    src = "/img/" + (19).ToString() + ".jpg";
                    this.PrimaryImage.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
                    break;

            }
        }

        private void SmallListing_MouseEnter(object sender, MouseEventArgs e)
        {
            SmallListingDropShadow.Visibility = Visibility.Visible;
        }

        private void SmallListing_MouseLeave(object sender, MouseEventArgs e)
        {
            SmallListingDropShadow.Visibility = Visibility.Hidden;
        }

    }


}
