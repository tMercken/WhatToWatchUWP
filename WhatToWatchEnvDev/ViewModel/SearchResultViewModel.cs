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
    public class SearchResultViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Movie> _movies;
        private Movie _selectedMovie;
        private INavigationService _navigationService;
        ImdbAccess dataImdb;

        [PreferredConstructor]
        public SearchResultViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            dataImdb = new ImdbAccess();
            Movies = new ObservableCollection<Movie>();
        }

        public ObservableCollection<Movie> Movies
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

        public async void GetAllMoviesFromTitle(String movieTitle)
        {
            List<Movie> listMovies = await dataImdb.GetMovieFromSearch(movieTitle);
            foreach (var item in listMovies)
            {
                Movies.Add(item);
            }
        }

        public async void GetAllMoviesFromAdvencedSearch(Movie searchedMovie)
        {
            List<Movie> listMovies = await dataImdb.GetMovieFromAdvencedSearch(searchedMovie);
            foreach (var item in listMovies)
            {
                Movies.Add(item);
            }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Movies.Clear();
            try
            {
                Movie searchedMovie = (Movie)e.Parameter;
                GetAllMoviesFromAdvencedSearch(searchedMovie);
            }
            catch
            {
                String movieTitle = (String)e.Parameter;
                GetAllMoviesFromTitle(movieTitle);
            }
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