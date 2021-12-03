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
        private string address;
        // default galleryNum is 3
        private int galleryNum = 3;
        private int index;

        public ListingGallery()
        {
            InitializeComponent();
        }

        private void CloseGallery(object sender, RoutedEventArgs e)
        {
            // Close the contact popup using the close button, or if the user clicked outside the popup
            this.Visibility = Visibility.Collapsed;
        }

        public void SetImages(string addr,string btn)
        {
            address = addr;
            btnName = btn;
            // default  gallery is gallery3
            int gallery = 3;

            // listing 1 (when sorted by new)
            if(addr.Equals("Pineridge Apartments, # 772706, 433 Pinestream Pl NE, Calgary, AB T1Y 3A5"))
            {
                SetBigImage(1);
                galleryNum = 1;
                gallery = 1;
            }
            // listing 2
            else if (addr.Equals("841 NE Royal Ave SW, Calgary, AB T2T 0L4"))
            {
                SetBigImage(2);
                galleryNum = 2;
                gallery = 2;
            }
            // listing 3 and onwards
            else
            {
                galleryNum = 3;
                SetBigImage(3);
            }

            string newImg = "/img/gallery" + gallery.ToString();
            this.Gallery0.Source = new BitmapImage(new Uri(newImg+"/0.jpg", UriKind.Relative));
            this.Gallery1.Source = new BitmapImage(new Uri(newImg+"/1.jpg", UriKind.Relative));
            this.Gallery2.Source = new BitmapImage(new Uri(newImg+"/2.jpg", UriKind.Relative));
            this.Gallery3.Source = new BitmapImage(new Uri(newImg+"/3.jpg", UriKind.Relative));
            this.Gallery4.Source = new BitmapImage(new Uri(newImg+"/4.jpg", UriKind.Relative));
        }

        private void SetBigImage(int i)
        {

            string newImg;
            if (btnName.Equals("LargeImage") || btnName.Equals("MoreBtn"))
            {
                Gallery0.BringIntoView();
                newImg = "/img/gallery" + i.ToString() + "/0.jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                this.BackBtn.Visibility = Visibility.Collapsed;
                index = 0;
            }
            else if (btnName.Equals("SmallImage1"))
            {
                Gallery1.BringIntoView();
                newImg = "/img/gallery" + i.ToString() + "/1.jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                index = 1;
            }
            else if (btnName.Equals("SmallImage2"))
            {
                newImg = "/img/gallery" + i.ToString() + "/2.jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                Gallery2.BringIntoView();
                index = 2;
            }
        }

        private void ChangeBigImage(object sender, MouseButtonEventArgs e)
        {
            string btn = (sender as Image).Name;
            if (btn.Equals("Gallery0"))
            {
                Gallery0.BringIntoView();
                string newImg = "/img/gallery" + galleryNum.ToString() + "/0.jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                this.NextBtn.Visibility = Visibility.Visible;
                this.BackBtn.Visibility = Visibility.Collapsed;
                index = 0;
            }
            else if (btn.Equals("Gallery1"))
            {
                Gallery1.BringIntoView();
                string newImg = "/img/gallery" + galleryNum.ToString() + "/1.jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                this.NextBtn.Visibility = Visibility.Visible;
                this.BackBtn.Visibility = Visibility.Visible;
                index = 1;
            }
            else if (btn.Equals("Gallery2"))
            {
                Gallery2.BringIntoView();
                string newImg = "/img/gallery" + galleryNum.ToString() + "/2.jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                this.NextBtn.Visibility = Visibility.Visible;
                this.BackBtn.Visibility = Visibility.Visible;
                index = 2;
            }
            else if (btn.Equals("Gallery3"))
            {
                Gallery3.BringIntoView();
                string newImg = "/img/gallery" + galleryNum.ToString() + "/3.jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                this.NextBtn.Visibility = Visibility.Visible;
                this.BackBtn.Visibility = Visibility.Visible;
                index = 3;
            }
            else if (btn.Equals("Gallery4"))
            {
                Gallery4.BringIntoView();
                string newImg = "/img/gallery" + galleryNum.ToString() + "/4.jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                this.NextBtn.Visibility = Visibility.Collapsed;
                index = 4;
            }
            //this.GalleryBigImg.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
        }

        
        private void GalleryNext(object sender, RoutedEventArgs e)
        {
            int next = index + 1;
            if (next <= 4 && index >= 0)
            {
                index++;
                int prev = next - 1;
                //string galleryJump = "Gallery" + galleryNum.ToString();
                //Image gall = galleryJump as Image;
                //gall.BringIntoView();
                string newImg = "/img/gallery" + galleryNum.ToString() + "/" + next.ToString() + ".jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                if (prev >= 0)
                {
                    this.BackBtn.Visibility = Visibility.Visible;
                }
                if(next == 4)
                {
                    this.NextBtn.Visibility = Visibility.Collapsed;
                }

            }
        }
       
        private void GalleryBack(object sender, RoutedEventArgs e)
        {
           int prev = index - 1;
           if (prev >= 0)
           {
                index--;
                int next = prev + 1;
                string newImg = "/img/gallery" + galleryNum.ToString() + "/" + prev.ToString() + ".jpg";
                this.GalleryBigImg.Source = new BitmapImage(new Uri(newImg, UriKind.Relative));
                if(next <= 4)
                {
                    this.NextBtn.Visibility = Visibility.Visible;
                }
                if(prev == 0)
                {
                    this.BackBtn.Visibility = Visibility.Collapsed;
                }
           }
        }

    }

    }
    
