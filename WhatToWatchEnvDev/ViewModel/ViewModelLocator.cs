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
            SimpleIoc.Default.Register<CategoryViewModel>();
            SimpleIoc.Default.Register<ListMoviesViewModel>();
            SimpleIoc.Default.Register<MovieDetailsViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<SearchResultViewModel>();
            SimpleIoc.Default.Register<AdvancedSearchViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<ListFavoritesViewModel>();

            NavigationService navigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("Category", typeof(Category));
            navigationService.Configure("ListMovies", typeof(ListMovies));
            navigationService.Configure("MovieDetails", typeof(MovieDetails));
            navigationService.Configure("Search", typeof(Search));
            navigationService.Configure("AdvancedSearch", typeof(AdvancedSearch));
            navigationService.Configure("SearchResult", typeof(SearchResult));
            navigationService.Configure("Home", typeof(Home));
            navigationService.Configure("Login", typeof(Login));
            navigationService.Configure("Register", typeof(Register));
            navigationService.Configure("ListFavorites", typeof(ListFavorites));

        }

        public MainPageViewModel MainView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public SearchViewModel Search
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        public AdvancedSearchViewModel AdvancedSearch
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AdvancedSearchViewModel>();
            }
        }

        public SearchResultViewModel SearchResult
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchResultViewModel>();
            }
        }

        public CategoryViewModel Category
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CategoryViewModel>();
            }
        }
        
        public ListMoviesViewModel ListMovies
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListMoviesViewModel>();
            }
        }

        public MovieDetailsViewModel MovieDetails
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MovieDetailsViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public RegisterViewModel Register
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterViewModel>();
            }
        }

        public ListFavoritesViewModel ListFavorites
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListFavoritesViewModel>();
            }
        }

    }
}



