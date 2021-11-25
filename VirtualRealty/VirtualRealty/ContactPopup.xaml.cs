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
    /// Interaction logic for ContactPopup.xaml
    /// </summary>
    public partial class ContactPopup : UserControl
    {
        public ContactPopup()
        {
            InitializeComponent();
        }

        public void SetContactInfo(string listingAddr)
        {
            this.ContactListAddress.Content = listingAddr;
        }

        private void CloseContactPopup(object sender, RoutedEventArgs e)
        {
            // Close the contact popup using the close button, or if the user clicked outside the popup
            this.Visibility = Visibility.Collapsed;
        }

        // Sets the textbox to blank when a user clicks it (removes default msg)
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            box.Text = "";
            box.GotFocus -= TextBox_GotFocus;
        }

        // If the user deselects textbox and leaves it blank, display default message
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox box = sender as TextBox;
            if (box.Text.Trim().Equals(string.Empty))
            {
                box.Text = box.Name.Equals("Message") ? "Enter your message here" : "Enter your email here";
                box.GotFocus += TextBox_GotFocus;
            }
        }

        // Copy label content to clipboard
        private void CopyBtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
