using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    class MoviesFromSearchTitleResponse
    {
        [JsonProperty("results")]
        public List<Movie> results { get; set; }
        
        [JsonProperty("page")]
        public int page { get; set; }

        public MoviesFromSearchTitleResponse(int page, List<Movie> movies)
        {
            this.page = page;
            this.results = movies;
        }


    }
}
