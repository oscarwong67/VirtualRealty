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

        public void SetListings(List<Listing> Listings)
        {
            int i = 0;

            foreach (Listing L in Listings)
            {
                switch (i % 3)
                {
                    case 0:
                        Left.Children.Add(L.Small);
                        break;
                    case 1:
                        Centre.Children.Add(L.Small);
                        break;
                    case 2:
                        Right.Children.Add(L.Small);
                        break;
                }

                i++;
            }
        }
    }
}
