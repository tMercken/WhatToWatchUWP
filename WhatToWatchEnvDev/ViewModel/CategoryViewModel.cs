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

namespace WhatToWatchEnvDev.ViewModel
{
    public class CategoryViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Category> _categories;
        private ObservableCollection<Movie> _movies;
        private Movie _selectedMovie;
        private INavigationService _navigationService;
        ImdbAccess dataImdb;
        private ICommand _showMovieCommand;

        public CategoryViewModel()
        {
        }

        [PreferredConstructor]
        public CategoryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            dataImdb = new ImdbAccess();
            Movies = new ObservableCollection<Movie>();
            //GetAllMovie();
        }

        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set
            {
                _movies = value;
                RaisePropertyChanged("Recipes");
            }
        }

        private ObservableCollection<Category> MyCategories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        public async void GetAllCategories()
        {
            List<Category> listCategories = await dataImdb.GetAllCategories();
            MyCategories = new ObservableCollection<Category> ();
            foreach (var item in listCategories)
            {
                MyCategories.Add(item);
            }
        }

        public void OnNavigatedTo()
        {
            GetAllCategories();
        }

        public async void GetAllMovies()
        {
            List<Movie> listRecipes = await dataImdb.GetAllMovies("");

            foreach (var item in listRecipes)
            {
                Movies.Add(item);
            }
        }

        public ICommand ShowMovieCommand
        {
            get
            {
                if (this._showMovieCommand == null)
                {
                    this._showMovieCommand = new RelayCommand(() => ShowRecipe());
                }
                return this._showMovieCommand;
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
            }
        }

        private void ShowRecipe()
        {
            if (CanExecute())
            {
                _navigationService.NavigateTo("Movie", SelectedMovie);
            }
        }

        public bool CanExecute()
        {
            if (SelectedMovie == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
    }
}
