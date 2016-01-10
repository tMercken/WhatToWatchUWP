using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.ComponentModel;
using System.Windows.Input;
using WhatToWatchEnvDev.Model;

namespace WhatToWatchEnvDev.ViewModel
{
    public class AdvancedSearchViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _searchCommand;
        private INavigationService _navigationService;
        private Movie _searchedMovie;

        public AdvancedSearchViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SearchedMovie = new Movie();
        }

        public ICommand SearchCommand
        {
            get
            {
                if (this._searchCommand == null)
                {
                    this._searchCommand = new RelayCommand(() => SearchNavigate());
                }
                return this._searchCommand;
            }
        }

        private void SearchNavigate()
        {
            if (CanLaunchSearch())
            {
                _navigationService.NavigateTo("SearchResult", SearchedMovie);
            }
        }

        public Movie SearchedMovie
        {
            get { return _searchedMovie; }
            set
            {
                _searchedMovie = value;
                RaisePropertyChanged("SearchedMovie");
            }
        }

        private bool CanLaunchSearch()
        {
            return (true);
        }
    }
}
