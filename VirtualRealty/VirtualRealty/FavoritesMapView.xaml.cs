
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
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI.Xaml.Controls.Maps;

namespace VirtualRealty
{
    /// <summary>
    /// Interaction logic for FavoritesMapView.xaml
    /// </summary>
    public partial class FavoritesMapView : UserControl
    {

        public List<Listing> Listings;
        Boolean LocationSort = false;
        DateTime LastSorted = DateTime.Now;

        public FavoritesMapView()
        {
            InitializeComponent();

            MapViewer2.Loaded += MapControl_Loaded;
            MapViewer2.ActualCameraChanged += MapControl_Moved;

        }


        public void ClearListings()
        {
            MapViewer2.MapElements.Clear();
            ListingViewer.Children.Clear();
        }

        public void SetListings(List<Listing> Listings)
        {
            this.Listings = Listings;

            ClearListings();

            MapElementsLayer Layer = new MapElementsLayer();
            Layer.MapElementClick += Layer_MapElementClick;

            foreach (Listing L in Listings)
            {
                ListingViewer.Children.Add(L.Small);
                L.Small.SetListingGrid(MapViewGrid);

                MapIcon Pin = new MapIcon();
                Geopoint Location = new Geopoint(new BasicGeoposition() { Latitude = L.Latitude, Longitude = L.Longitude });
                Pin.Location = Location;

                Pin.Tag = L;

                Layer.MapElements.Add(Pin);
            }

            MapViewer2.Layers.Add(Layer);
        }

        private void Layer_MapElementClick(MapElementsLayer sender, MapElementsLayerClickEventArgs args)
        {
            (args.MapElements.FirstOrDefault().Tag as Listing).Small.BringIntoView();
        }

        private void MapControl_Moved(object sender, object e)
        {

            if (MapViewer2.ActualCamera == null || !LocationSort)
            {
                return;
            }

            if (LastSorted.AddSeconds(2) >= DateTime.Now) return;

            LastSorted = DateTime.Now;

            ListingComparer Comp = new ListingComparer(ListingComparer.SortBy.Proximity);
            Comp.SetLocation(MapViewer2.ActualCamera.Location);

            Listings.Sort(Comp);

            this.SetListings(Listings);

        }

        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 51.0447, Longitude = -114.0719 };
            var cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            await (sender as Microsoft.Toolkit.Wpf.UI.Controls.MapControl).TrySetViewAsync(cityCenter, 11);
        }

        public void ListView_Click(Object Sender, RoutedEventArgs args)
        {
            Switcher.Switch(MainWindow.FavouritesPage);
            List<Listing> temp = Listings;
            ClearListings();
            MainWindow.FavouritesPage.SetListings(temp);
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
                LocationSort = false;
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.DateFavourited));
            }
            else if (text.Equals("Date Favourited (Oldest)"))
            {
                LocationSort = false;
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.DateFavourited, true /* Descending */));
            }
            else if (text.Equals("Newest"))
            {
                LocationSort = false;
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.DateListed));
            }
            else if (text.Equals("Oldest"))
            {
                LocationSort = false;
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.DateListed, true /* Descending */));
            }
            else if (text.Equals("Price (Low to High)"))
            {
                LocationSort = false;
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.Price, true));
            }
            else if (text.Equals("Price (High to Low)"))
            {
                LocationSort = false;
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.Price));
            }
            else
            {
                LocationSort = true;
            }
            SetListings(sortedListings);
        }
    }
}
