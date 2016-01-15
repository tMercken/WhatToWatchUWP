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
using Windows.UI.Xaml;

namespace WhatToWatchEnvDev.ViewModel
{
    public class HomeViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private String _welcomeMessage = "Welcome";
        private INavigationService _navigationService;
        private ICommand _loginCommand;
        private ICommand _RegisterCommand;
        private ICommand _logoutCommand;
        private ImdbAccess dataImdb;
        private App currentApp = Application.Current as App;
        
        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            dataImdb = new ImdbAccess();            
        }

        public Boolean IsConnected
        {
            get { return currentApp.GlobalInstance.IsUserEmpty(); }
        }

        public String WelcomeMessage
        {
            get
            {
                if (currentApp.GlobalInstance.IsUserEmpty())
                {
                    return _welcomeMessage;
                }
                return _welcomeMessage + " " + currentApp.GlobalInstance.GlobalUser.email;
            }
            set
            {
                _welcomeMessage = value;
                RaisePropertyChanged("WelcomeMessage");
            }
        }

        public void OnNavigatedTo()
        {

        }

        public ICommand LoginCommand
        {
            get
            {
                if (this._loginCommand == null)
                {
                    this._loginCommand = new RelayCommand(() => LoginNavigate());
                }
                return this._loginCommand;
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                if (this._logoutCommand == null)
                {
                    this._logoutCommand = new RelayCommand(() => Logout());
                }
                return this._logoutCommand;
            }
        }

        public void Logout()
        {
            currentApp.GlobalInstance.GlobalUser = null;
            _navigationService.NavigateTo("Home");
        }

        public void LoginNavigate()
        {
            _navigationService.NavigateTo("Login");
        }

        public ICommand RegisterCommand
        {
            get
            {
                if (this._RegisterCommand == null)
                {
                    this._RegisterCommand = new RelayCommand(() => RegisterNavigate());
                }
                return this._RegisterCommand;
            }
        }

        public void RegisterNavigate()
        {
            _navigationService.NavigateTo("Register");
        }
        
    }
}

