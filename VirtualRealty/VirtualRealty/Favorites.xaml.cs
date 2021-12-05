using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
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
    /// Interaction logic for Favorites.xaml
    /// </summary>
    public partial class Favorites : UserControl
    {

        public List<Listing> Listings;
        public Favorites()
        {
            InitializeComponent();
        }

        public List<Listing> getListings()
        {
            return Listings;
        }


        public void ClearListings()
        {
            Listings = new List<Listing>();
            LeftFaves.Children.Clear();
            CentreFaves.Children.Clear();
            RightFaves.Children.Clear();
        }

        public void SetListings(List<Listing> Listings)
        {
            int i = 0;
            ClearListings();
            this.Listings = Listings;
            foreach (Listing L in Listings)
            {
                L.Small.ShowPurchaseOrRental();
                switch (i % 3)
                {
                    case 0:
                        LeftFaves.Children.Add(L.Small);
                        L.Small.SetListingGrid(this.FavesPgGrid);
                        //L.Small.SetListingGrid();
                        L.Small.SetListingInd(Listings, i);
                        L.Small.SetDisplayImage(L);
                        break;
                    case 1:
                        CentreFaves.Children.Add(L.Small);
                        L.Small.SetListingGrid(this.FavesPgGrid);
                        L.Small.SetListingInd(Listings, i);
                        L.Small.SetDisplayImage(L);
                        break;
                    case 2:
                        RightFaves.Children.Add(L.Small);
                        L.Small.SetListingGrid(this.FavesPgGrid);
                        L.Small.SetListingInd(Listings, i);
                        L.Small.SetDisplayImage(L);
                        break;
                }
                i++;
            }
        }

        public void MapView_Click(Object Sender, RoutedEventArgs args)
        {
            Switcher.Switch(MainWindow.FavouritesMapViewPage);
            List<Listing> temp = Listings;
            foreach (Listing l in temp)
            {
                l.Small.SetListingGrid(MainWindow.FavouritesMapViewPage.MapViewGrid);
            }
            ClearListings();
            MainWindow.FavouritesMapViewPage.SetListings(temp);
        }

        private void SortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listings == null || Listings.Count == 0)
            {
                return;
            }
            List<Listing> sortedListings = new List<Listing>(Listings);

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text.Equals("Date Favourited (Newest)"))
            {
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.DateFavourited));
            } else if (text.Equals("Date Favourited (Oldest)"))
            {
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.DateFavourited, true /* Descending */));
            }
            else if (text.Equals("Newest"))
            {
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.DateListed));
            }
            else if (text.Equals("Oldest"))
            {
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.DateListed, true /* Descending */));
            }
            else if (text.Equals("Price (Low to High)"))
            {
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.Price, true));
            }
            else if (text.Equals("Price (High to Low)"))
            {
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.Price));
            }
            else
            {
                Geopoint Calgary = new Geopoint(new Windows.Devices.Geolocation.BasicGeoposition() { Latitude = 51.0447, Longitude = 114.0719 });

                ListingComparer Comp = new ListingComparer(ListingComparer.SortBy.Proximity);
                Comp.SetLocation(Calgary);

                sortedListings.Sort(Comp);
            }
            SetListings(sortedListings);
        }
    }
}
