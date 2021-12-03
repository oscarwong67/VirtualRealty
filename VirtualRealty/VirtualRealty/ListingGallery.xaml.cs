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
    /// Interaction logic for ListingGallery.xaml
    /// </summary>
    public partial class ListingGallery : UserControl
    {

        private string btnName;
        public ListingGallery()
        {
            InitializeComponent();
        }

        private void CloseGallery(object sender, RoutedEventArgs e)
        {
            // Close the contact popup using the close button, or if the user clicked outside the popup
            this.Visibility = Visibility.Collapsed;
        }

        public void SetBigImage(string name)
        {
            btnName = name;
            string newImg = "/img/" + (5).ToString() + ".jpg";
            this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
        }

        private void ChangeBigImage(object sender, MouseButtonEventArgs e)
        {
            //string src = "/img/" + (5).ToString() + ".jpg";
            string btn = (sender as Image).Name;
            if(btn.Equals("Gallery1"))
            {
                string newImg = "/img/" + (1).ToString() + ".jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
            }
            else if(btn.Equals("Gallery2"))
            {
                string newImg = "/img/" + (2).ToString() + ".jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
            }
            else if (btn.Equals("Gallery3"))
            {
                string newImg = "/img/" + (3).ToString() + ".jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
            }
            else if (btn.Equals("Gallery4"))
            {
                string newImg = "/img/" + (4).ToString() + ".jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
            }
            else if (btn.Equals("Gallery5"))
            {
                string newImg = "/img/" + (5).ToString() + ".jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
            }
            //this.GalleryBigImg.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
        }

        /**
        private void GalleryNext(object sender, RoutedEventArgs e)
        {
            if (next < ListingsList.Count && next >= 0)
            {
                SetBigListing(ListingsList[next]);
                SetThumbnailImages(next);
                next++;
                prev++;
                if (prev >= 0)
                {
                    this.BackBtn.Visibility = Visibility.Visible;
                }
                if (next >= ListingsList.Count)
                {
                    this.NextBtn.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void GalleryBack(object sender, RoutedEventArgs e)
        {

            if (prev >= 0)
            {
                SetBigListing(ListingsList[prev]);
                SetThumbnailImages(prev);
                prev--;
                next--;
                if (prev < 0)
                {
                    this.BackBtn.Visibility = Visibility.Collapsed;
                }
                if (next <= ListingsList.Count)
                {
                    this.NextBtn.Visibility = Visibility.Visible;
                }
            }
        }

        */
    }

}
