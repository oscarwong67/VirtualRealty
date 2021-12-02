
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
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {

        public List<Listing> Listings;

        public MapView()
        {
            InitializeComponent();

            MapViewer.Loaded += MapControl_Loaded;
            ;
        }


        public void ClearListings()
        {
            MapViewer.MapElements.Clear();
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

            MapViewer.Layers.Add(Layer);
        }

        private void Layer_MapElementClick(MapElementsLayer sender, MapElementsLayerClickEventArgs args)
        {
            (args.MapElements.FirstOrDefault().Tag as Listing).Small.BringIntoView();
        }



        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 51.0447, Longitude = -114.0719 };
            var cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            await (sender as Microsoft.Toolkit.Wpf.UI.Controls.MapControl).TrySetViewAsync(cityCenter, 11);
        }

        public void ListView_Click(Object Sender,RoutedEventArgs args)
        {
            Switcher.Switch(MainWindow.LP);
            List<Listing> temp = Listings;
            ClearListings();
            MainWindow.LP.SetListings(temp);
        }

        private void SortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listings == null || Listings.Count == 0)
            {
                return;
            }
            List<Listing> sortedListings = new List<Listing>(Listings);

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text.Equals("Newest"))
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
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.Proximity));
            }
            SetListings(sortedListings);
        }
    }
}
