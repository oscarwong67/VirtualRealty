using System.Windows;
using System.Windows.Controls;

namespace VirtualRealty
{
    /// <summary>
    /// Interaction logic for Top_Bar.xaml
    /// </summary>
    public partial class Top_Bar : UserControl
    {
        public Top_Bar()
        {
            InitializeComponent();
        }

        void GoToFavorites(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Favorites());
        }

        void GoToSavedSearches(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new SavedSearches());
        }
    }
}
