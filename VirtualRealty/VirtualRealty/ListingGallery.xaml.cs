﻿using System;
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
        public ListingGallery()
        {
            InitializeComponent();
        }
    }

    private void ChangeBigImage(object sender, MouseButtonEventArgs e)
    {
        string src = "/img/" + i.ToString() + ".jpg";

        this.GalleryBigImg.Source = new BitmapImage(new Uri(@src, UriKind.Relative));
    }

}
