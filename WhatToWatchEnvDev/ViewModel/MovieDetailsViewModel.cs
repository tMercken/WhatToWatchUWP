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
using Windows.UI.Xaml;

namespace WhatToWatchEnvDev.ViewModel
{
    public class MovieDetailsViewModel
    {   
        private Movie _selectedMovie;
        private INavigationService _navigationService;        
        private App currentApp = Application.Current as App;
        private AzureApiAccess dataAzure;
        private ICommand _addToFavoritesCommand;
        private ICommand _removeFromFavoritesCommand;


        public MovieDetailsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            dataAzure = new AzureApiAccess();
            ChosenMovie = new Movie();
            
        }

        public ICommand AddToFavoritesCommand
        {
            get
            {
                if (this._addToFavoritesCommand == null)
                {
                    this._addToFavoritesCommand = new RelayCommand(() => AddToFavorites());
                }
                return this._addToFavoritesCommand;
            }
        }

        public async void AddToFavorites()
        {
            if (!currentApp.GlobalInstance.IsUserEmpty() && !IsInGlobalUserFavorite)
            {
                Boolean successFulAdding = await dataAzure.AddToFavorite(ChosenMovie);
                if (successFulAdding)
                {
                    //note: make a toast
                    _navigationService.NavigateTo("ListFavorites");
                }
                else
                {

                }
            }
        }

        public ICommand RemoveFromFavoritesCommand
        {
            get
            {
                if (this._removeFromFavoritesCommand == null)
                {
                    this._removeFromFavoritesCommand = new RelayCommand(() => RemoveFromFavorites());
                }
                return this._removeFromFavoritesCommand;
            }
        }

        public async void RemoveFromFavorites()
        {
            if (!currentApp.GlobalInstance.IsUserEmpty() && IsInGlobalUserFavorite)
            {
                Boolean successfulRemoval = await dataAzure.RemoveFavorite(ChosenMovie);

                if (successfulRemoval)
                {
                    //note: make a toast
                    _navigationService.NavigateTo("ListFavorites");
                }
                else
                {

                }
            }
        }

        public String PosterPath
        {
            get
            {
                return "https://image.tmdb.org/t/p/w500" + ChosenMovie.poster_path;
            }
        }

        private Boolean IsInGlobalUserFavorite
        {
            get
            {
                if (!currentApp.GlobalInstance.IsUserEmpty() && currentApp.GlobalInstance.GlobalUser.IsMovieInFavorite(ChosenMovie))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
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

