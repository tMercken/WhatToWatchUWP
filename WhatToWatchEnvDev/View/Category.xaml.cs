﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WhatToWatchEnvDev.Data;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WhatToWatchEnvDev.Model;
using WhatToWatchEnvDev.ViewModel;
// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace WhatToWatchEnvDev.View
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Category : Page
    {
        private ObservableCollection<Model.Category> categories;

        public Category()
        {
            this.InitializeComponent();
            ImdbAccess imdbAccess = new ImdbAccess();
            test1.Text = imdbAccess.getTestString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((CategoryViewModel)DataContext).OnNavigatedTo();

            //base.OnNavigatedTo(e);
        }
    }
}
