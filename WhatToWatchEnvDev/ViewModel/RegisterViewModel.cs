using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WhatToWatchEnvDev.Data;
using WhatToWatchEnvDev.Model;
using Windows.UI.Xaml;

namespace WhatToWatchEnvDev.ViewModel
{
    public class RegisterViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _registerCommand;
        private INavigationService _navigationService;
        private String _email;
        private String _password;
        private String _confirmPassword;
        private App currentApp = Application.Current as App;
        private AzureApiAccess dataAzure;

        public RegisterViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            dataAzure = new AzureApiAccess();
        }

        public ICommand RegisterCommand
        {
            get
            {
                if (this._registerCommand == null)
                {
                    this._registerCommand = new RelayCommand(() => SignIn());
                }
                return this._registerCommand;
            }
        }

        public String Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public String ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                RaisePropertyChanged("ConfirmPassword");
            }
        }

        private async void SignIn()
        {
            if (CanLogin())
            {
                Boolean registerSuccessful = await dataAzure.createUser(Email, Password);
                if (registerSuccessful)
                {
                    _navigationService.NavigateTo("Home");
                }
                else
                {

                }
            }
        }

        private bool CanLogin()
        {
            return (Email != null && Password != null && Password == ConfirmPassword);
        }
    }
}
