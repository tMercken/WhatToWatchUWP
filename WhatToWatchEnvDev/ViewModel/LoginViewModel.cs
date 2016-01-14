using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WhatToWatchEnvDev.Data;
using WhatToWatchEnvDev.Model;
using Windows.UI.Notifications;
using Windows.UI.Xaml;

namespace WhatToWatchEnvDev.ViewModel
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ICommand _loginCommand;
        private INavigationService _navigationService;
        private String _email;
        private String _password;
        private App currentApp = Application.Current as App; 
        private AzureApiAccess dataAzure;
        User MyMyUser { get; set; }

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            dataAzure = new AzureApiAccess();
        }

        public ICommand LoginCommand
        {
            get
            {
                if (this._loginCommand == null)
                {
                    this._loginCommand = new RelayCommand(() => Log_In());
                }
                return this._loginCommand;
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

        public async void Log_In()
        {
            if (CanLogin())
            {
                Boolean loginReussit = await dataAzure.GetUser(Email, Password);
                if (loginReussit)
                {
                    createToast("Login successful");
                    _navigationService.NavigateTo("Home");
                }
                else
                {
                    createToast("Error : email and password don't match");
                }
            }
        }

        private bool CanLogin()
        {
            return (Email != null && Password != null);
        }   

        public void createToast(String value)
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            ToastVisual visual = new ToastVisual()
            {
                TitleText = new ToastText()
                {

                    Text = loader.GetString(value)
                },
            };

            ToastContent toastContent = new ToastContent();
            toastContent.Visual = visual;
            var toast = new ToastNotification(toastContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }     
    }
}
