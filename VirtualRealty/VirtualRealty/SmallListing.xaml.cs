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
        public SmallListing()
        {
            InitializeComponent();
        }

        public void SetListing(Listing L)
        {
            Listing = L;

            this.Price.Content = "$" + Listing.Price.ToString();
            this.Address.Content = Listing.Address;
            this.Type.Content = L.ListingType.ToString();
            this.BedBath.Content = Listing.Beds.ToString() + " Beds, " + Listing.Baths.ToString() + " Baths";
            this.Size.Content = Listing.size.ToString() + "ft^2";
        }
    }
}
