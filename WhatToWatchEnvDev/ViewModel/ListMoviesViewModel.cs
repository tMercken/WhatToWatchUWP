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
    public class ListMoviesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Movie> _movies;
        private Movie _selectedMovie;
        private INavigationService _navigationService;
        ImdbAccess dataImdb;
        
        public ListMoviesViewModel(INavigationService navigationService)
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


        public async void GetAllMovies(int idCategory)
        {
            List<Movie> listMovies = await dataImdb.GetMovieFromCategory(idCategory);
            foreach (var item in listMovies)
            {
                Movies.Add(item);
            }
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Movies.Clear();
            Category selectedCategory = (Category)e.Parameter;
            GetAllMovies(selectedCategory.Id);
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

