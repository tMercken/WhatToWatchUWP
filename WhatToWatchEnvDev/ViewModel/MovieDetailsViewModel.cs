using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System.ComponentModel;
using System.Windows.Input;
using Windows.UI.Core;
using WhatToWatchEnvDev.Data;
using WhatToWatchEnvDev.Model;
using Windows.UI.Xaml.Navigation;

namespace WhatToWatchEnvDev.ViewModel
{
    public class MovieDetailsViewModel
    {   
        private Movie _selectedMovie;
        private INavigationService _navigationService;

        public MovieDetailsViewModel()
        {
            ChosenMovie = new Movie();
        }

        [PreferredConstructor]
        public MovieDetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ChosenMovie = new Movie();
        }

        public Movie ChosenMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
            }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            ChosenMovie = (Movie)e.Parameter;
        }

    }
}

