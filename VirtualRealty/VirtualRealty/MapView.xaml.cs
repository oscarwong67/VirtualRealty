
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
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
using Windows.Services.Maps;

namespace VirtualRealty
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView : UserControl
    {
        public MapView()
        {
            InitializeComponent();

            MapViewer.Loaded += MapControl_Loaded;
        }



        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 51.0447, Longitude = -114.0719 };
            var cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            await (sender as MapControl).TrySetViewAsync(cityCenter, 11);
        }

        public void ListView_Click(Object Sender,RoutedEventArgs args)
        {
            Switcher.Switch(MainWindow.LP);
        }
    }
}
