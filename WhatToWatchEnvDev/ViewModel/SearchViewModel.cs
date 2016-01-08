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

namespace WhatToWatchEnvDev.ViewModel
{ 
    public class SearchViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _searchCommand;
        private INavigationService _navigationService;

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

        private void SearchNavigate()
        {
            _navigationService.NavigateTo("ListMovies");
        }

    }
}
