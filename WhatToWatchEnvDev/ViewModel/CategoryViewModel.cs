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
    public sealed class CategoryViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<Category> _categories;
        private Category _selectedCategory;
        private INavigationService _navigationService;
        ImdbAccess dataImdb;
        //public NavigationService nav;

        public CategoryViewModel()
        {
            dataImdb = new ImdbAccess();
            Categories = new ObservableCollection<Category>();
        }

        [PreferredConstructor]
        public CategoryViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            //nav = new NavigationService();
            dataImdb = new ImdbAccess();
            Categories = new ObservableCollection<Category>();
        }
        

        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        private void ChooseCategory()
        {        
                // myFrame.Navigate(typeof(View.Home));
                
                //nav.Configure("ListMovies", typeof(View.ListMovies));
                //nav.NavigateTo("ListMovies");
           _navigationService.NavigateTo("ListMovies", SelectedCategory);
            
        }

        public async void GetAllCategories()
        {
            List<Category> listCategories = await dataImdb.GetAllCategories();
            foreach (var item in listCategories)
            {
                Categories.Add(item);
            }
        }

        public void OnNavigatedTo()
        {
            GetAllCategories();
        }

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                if (_selectedCategory != null)
                {
                    RaisePropertyChanged("SelectedCategory");
                    ChooseCategory();
                }
            }
        }

    }
}
