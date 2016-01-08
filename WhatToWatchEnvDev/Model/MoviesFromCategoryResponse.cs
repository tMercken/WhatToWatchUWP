using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    class MoviesFromCategoryResponse
    {

        [JsonProperty("results")]
        public List<Movie> results { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("page")]
        public int page { get; set; }

        public MoviesFromCategoryResponse(int id, int page, List<Movie> movies)
        {
            this.id = id;
            this.page = page;
            this.results = movies;
        }


    }
}
