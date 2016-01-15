using GalaSoft.MvvmLight.Ioc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    public class Favori
    {
        [JsonProperty("id")]
        public int? id { get; set; }

        [JsonProperty("idFilm")]
        public int idMovie { get; set; }

        [JsonProperty("email")]
        public String emailUser { get; set; }

        /*
        public Favori(int idMovie, String emailForeignKey)
        {
            this.idMovie = idMovie;
            this.emailUser = emailForeignKey;
        }*/
        
        public Favori(int? id, int idMovie, String emailForeignKey)
        {
            this.id = id;
            this.idMovie = idMovie;
            this.emailUser = emailForeignKey;
        }
    }
}
