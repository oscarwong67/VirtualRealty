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
    /// Interaction logic for ListingsPage.xaml
    /// </summary>
    public partial class ListingsPage : UserControl
    {

        public List<Listing> Listings;
        public ListingsPage()
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
            Left.Children.Clear();
            Centre.Children.Clear();
            Right.Children.Clear();
        }

        public void SetListings(List<Listing> Listings)
        {
            int i = 0;
            ClearListings();
            this.Listings = Listings;
            foreach (Listing L in Listings)
            {
                switch (i % 3)
                {
                    case 0:
                        Left.Children.Add(L.Small);
                        L.Small.SetListingGrid(this.ListingPgGrid);
                        //L.Small.SetListingGrid();
                        L.Small.SetListingInd(Listings, i);
                        L.Small.SetDisplayImage(i);
                        break;
                    case 1:
                        Centre.Children.Add(L.Small);
                        L.Small.SetListingGrid(this.ListingPgGrid);
                        L.Small.SetListingInd(Listings, i);
                        L.Small.SetDisplayImage(i);
                        break;
                    case 2:
                        Right.Children.Add(L.Small);
                        L.Small.SetListingGrid(this.ListingPgGrid);
                        L.Small.SetListingInd(Listings, i);
                        L.Small.SetDisplayImage(i);
                        break;
                }
                i++;
            }
        }

        public void MapView_Click(Object Sender, RoutedEventArgs args)
        {
            Switcher.Switch(MainWindow.MapViewPage);
            List<Listing> temp = Listings;
            foreach (Listing l in temp) {
                l.Small.SetListingGrid(MainWindow.MapViewPage.MapViewGrid);
            }
            ClearListings();
            MainWindow.MapViewPage.SetListings(temp);
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
            } else
            {
                sortedListings.Sort(new ListingComparer(ListingComparer.SortBy.Proximity));
            }
            SetListings(sortedListings);
        }
    }
}
