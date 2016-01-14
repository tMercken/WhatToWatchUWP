using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhatToWatchEnvDev
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(View.Home));
            WhatToWatchTitle.Text = "WhatToWatch";
            BackButton.Visibility = Visibility.Collapsed;
            HomeListBoxItem.IsSelected = true;
        }

        private void Hambutton_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMenu.IsPaneOpen = !SplitViewMenu.IsPaneOpen;

            //if (SplitViewMenu.Visibility == Visibility.Collapsed)
            //{
            //    SplitViewMenu.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    SplitViewMenu.Visibility = Visibility.Collapsed;
            //}
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            
        }

        private void IconListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         if (HomeListBoxItem.IsSelected)
            {
                Frame.Navigate(typeof(View.Home));
                BackButton.Visibility = Visibility.Collapsed;
            }   
         else if (SearchListBoxItem.IsSelected)
            {
                Frame.Navigate(typeof(View.Search));
                BackButton.Visibility = Visibility.Visible;
            }
         else if (CategoryListBoxItem.IsSelected)
            {
                Frame.Navigate(typeof(View.Category));
                BackButton.Visibility = Visibility.Visible;
            }

        }
    }
}
