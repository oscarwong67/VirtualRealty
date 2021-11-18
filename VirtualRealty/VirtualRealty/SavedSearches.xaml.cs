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
    /// Interaction logic for SavedSearches.xaml
    /// </summary>
    public partial class SavedSearches : UserControl
    {
        public static List<SavedSearch> savedSearches;

        public SavedSearches()
        {
            InitializeComponent();
            if (SavedSearchesSection.Children.Count == 0)
            {
                savedSearches.Sort(new SavedSearchComparer(SavedSearchComparer.SortBy.LastAccessed));
                foreach (SavedSearch savedSearch in savedSearches)
                {
                    SavedSearchesSection.Children.Add(savedSearch);
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SavedSearchesSection == null || SavedSearchesSection.Children == null || SavedSearchesSection.Children.Count == 0)
            {
                return;
            }
            SavedSearchesSection.Children.Clear();

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            if (text.Equals("Last Accessed"))
            {
                savedSearches.Sort(new SavedSearchComparer(SavedSearchComparer.SortBy.LastAccessed));
            } else if (text.Equals("Date Saved (Newest)"))
            {
                savedSearches.Sort(new SavedSearchComparer(SavedSearchComparer.SortBy.DateSavedNewest));
            } else
            {
                savedSearches.Sort(new SavedSearchComparer(SavedSearchComparer.SortBy.DateSavedOldest));
            }
            foreach (SavedSearch savedSearch in savedSearches)
            {
                SavedSearchesSection.Children.Add(savedSearch);
            }
        }
    }
}
