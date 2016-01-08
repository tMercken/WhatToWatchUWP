using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WhatToWatchEnvDev.Model;

namespace WhatToWatchEnvDev.Data
{
    class ImdbAccess
    {
        private HttpClient client;
        private String apiKey = "cc571afb50c2a89ff9f46b85c4e36a9d";
        private String AllMoviefromGenreFirstPartUrl = "http://api.themoviedb.org/3/genre/";
        private String AllMoviefromGenreSecondPartUrl = "/movies?api_key=";
        private String allGenreUrl = "http://api.themoviedb.org/3/genre/movie/list?api_key=";

        public ImdbAccess()
        {        
        }

        
       public async Task<List<Movie>> GetAllMovies()
        {/*
            client.BaseAddress = new Uri("http://food2fork.com/api/search?key=217401dcb0a4ad131cd118a528ce6cb4&q=");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(movie);
            string json = await response.Content.ReadAsStringAsync();
            var movies = new List<Movie>();
            var imdbResponse = JsonConvert.DeserializeObject<ImdbResponse>(json);
            string l = "oll";
            if (imdbResponse == null)
            {
                string m = "ferfe";
            }

            if (imdbResponse.movies.Any())
            {
                movies = imdbResponse.movies;
            }*/
                var movies = new List<Movie>();
            return movies;

        }

        public async Task<List<Movie>> GetMovieFromCategory(int categoryID)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(AllMoviefromGenreFirstPartUrl + categoryID.ToString() + AllMoviefromGenreSecondPartUrl + apiKey);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("");

            string json = await response.Content.ReadAsStringAsync();            
            var movies = new List<Movie>();
            var moviesResponse = JsonConvert.DeserializeObject<MoviesFromCategoryResponse>(json);

            if (moviesResponse.results.Any())
            {
                movies = moviesResponse.results;
            }

            return movies;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(allGenreUrl + apiKey);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("");

            string json = await response.Content.ReadAsStringAsync();
            var categories = new List<Category>();
            var categoriesResponse = JsonConvert.DeserializeObject<AllCategoriesResponse>(json);

            if (categoriesResponse.genres.Any())
            {
                categories = categoriesResponse.genres;
            }

            return categories;
        }


    }
}
