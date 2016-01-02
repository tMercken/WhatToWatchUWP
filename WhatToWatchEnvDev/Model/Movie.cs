using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    public class Movie
    {
        public String originalLanguage { get; set; }
        public String title { get; set; }
        public String releastDate { get; set; }
        public String posterPath { get; set; }
        public String overView { get; set; }
        public String category { get; set; }
        public int id { get; set; }
        public int voteAverage { get; set; }
        public int popularity { get; set; }

        public Movie(String originalLanguage, String title, String releastDate, String posterPath, String overView, String category, int id, int voteAverage, int popularity)
        {
            this.originalLanguage = originalLanguage;
            this.title = title;
            this.releastDate = releastDate;
            this.posterPath = posterPath;
            this.overView = overView;
            this.category = category;
            this.id = id;
            this.voteAverage = voteAverage;
            this.popularity = popularity;
        }
    }
}
