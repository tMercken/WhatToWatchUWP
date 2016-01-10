using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    public class Movie
    {
        [JsonProperty("original_language")]
        public String original_language { get; set; }

        [JsonProperty("original_title")]
        public String original_title { get; set; }

        [JsonProperty("release_date")]
        public String release_date { get; set; }

        [JsonProperty("poster_path")]
        public String poster_path { get; set; }

        [JsonProperty("overview")]
        public String overview { get; set; }

        [JsonProperty("backdrop_path")]
        public String backdrop_path { get; set; }

        [JsonProperty("title")]
        public String title { get; set; }

     //   [JsonProperty("genre_ids")]
      //  public Array genre_ids { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("vote_average")]
        public Double vote_average { get; set; }

        [JsonProperty("popularity")]
        public Double popularity { get; set; }

        [JsonProperty("vote_count")]
        public int vote_count { get; set; }

        [JsonProperty("video")]
        public Boolean video { get; set; }

        //        public Movie(String backdropPath, Array categories, int id, String originalLanguage, String title, String overView, String releastDate, String posterPath, int popularity, String englishTitle, Boolean video, int voteAverage, int voteCount )

        public Movie(String backdropPath, int id, String originalLanguage, String title, String overView, String releastDate, String posterPath, Double popularity, String englishTitle, Boolean video, Double voteAverage, int voteCount )
        {
            this.backdrop_path = backdropPath;
            this.title = englishTitle;
            this.video = video;
            this.vote_count = voteCount;
            this.original_language = originalLanguage;
            this.original_title = title;
            this.release_date = releastDate;
            this.poster_path = posterPath;
            this.overview = overView;
            //this.genre_ids = null;
            this.id = id;
            this.vote_average = voteAverage;
            this.popularity = popularity;
        }

        public Movie(String originalLanguage, String title, String releastDate, String posterPath, String overView, int id, Double voteAverage, Double popularity)
        {
            this.original_language = originalLanguage;
            this.original_title = title;
            this.release_date = releastDate;
            this.poster_path = posterPath;
            this.overview = overView;
        //    this.genre_ids = categories;
            this.id = id;
            this.vote_average = voteAverage;
            this.popularity = popularity;
        }

        public Movie()
        {

        }
    }
}
