using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWatchEnvDev.Data;
using WhatToWatchEnvDev.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace WhatToWatchEnvDev.ViewModel
{
    public class ListFavoritesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Movie> _movies;
        private Movie _selectedMovie;
        private INavigationService _navigationService;
        ImdbAccess dataImdb;
        private App currentApp = Application.Current as App;

        public ListFavoritesViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            dataImdb = new ImdbAccess();
            FavoritesMovies = new ObservableCollection<Movie>();
        }

        public ObservableCollection<Movie> FavoritesMovies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                RaisePropertyChanged("Movies");
            }
        }

        private void chooseMovie()
        {
            _navigationService.NavigateTo("MovieDetails", SelectedMovie);
        }


        public async void GetAllMoviesFromFavorites()
        {
            if (!currentApp.GlobalInstance.IsUserEmpty())
            {
                List<Movie> listMovies = await dataImdb.GetMovieFromGlobalUserFavorites();
                foreach (Movie item in listMovies)
                {
                    FavoritesMovies.Add(item);
                }
            }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            FavoritesMovies.Clear();
            GetAllMoviesFromFavorites();
        }

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                _selectedMovie = value;
                if (_selectedMovie != null)
                {
                    RaisePropertyChanged("SelectedMovie");
                }
                chooseMovie();
            }
        }

    }
}
