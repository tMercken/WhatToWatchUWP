using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatToWatchEnvDev.View;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace WhatToWatchEnvDev.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<CategoryViewModel>();

            NavigationService navigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("Search", typeof(Search));
            navigationService.Configure("Category", typeof(Category));
        }

        public MainPageViewModel MainView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public SearchViewModel SearchMovie
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        public CategoryViewModel Category
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CategoryViewModel>();
            }
        }

    }
}



