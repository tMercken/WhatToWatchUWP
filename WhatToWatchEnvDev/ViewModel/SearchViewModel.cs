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
using Windows.UI.Xaml.Navigation;

namespace WhatToWatchEnvDev.ViewModel
{ 
    public class SearchViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _searchCommand;
        private ICommand _advancedSearchCommand;
        private INavigationService _navigationService;
        private String _movieTitle;

        public SearchViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand SearchCommand
        {
            get
            {
                if (this._searchCommand == null)
                {
                    this._searchCommand = new RelayCommand(() =>SearchNavigate());
                }
                return this._searchCommand;
            }
        }

        public ICommand AdvancedSearchCommand
        {
            get
            {
                if (this._advancedSearchCommand == null)
                {
                    this._advancedSearchCommand = new RelayCommand(() => AdvancedSearchNavigate());
                }
                return this._advancedSearchCommand;
            }
        }

        public void AdvancedSearchNavigate()
        {
            _navigationService.NavigateTo("AdvancedSearch");
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            this._movieTitle = null;
        }

        public String MovieTitle
        {
            get { return _movieTitle; }
            set
            {
                _movieTitle = value;
                RaisePropertyChanged("MovieTitle");
            }
        }

        private void SearchNavigate()
        {
            if (CanLaunchSearch()) {
                _navigationService.NavigateTo("SearchResult", MovieTitle);
            }
        }

        private bool CanLaunchSearch()
        {
            return (MovieTitle != null);
        }

    }
}
