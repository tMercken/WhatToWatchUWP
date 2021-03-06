﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    public class User
    {
        public String email { get; set; }
        public String password { get; set; }
        public List<Favori> ListFavoris { get; set; }

        public bool IsMovieInFavorite(Movie movie)
        {
            if (this.ListFavoris != null)
            {
                foreach(Favori item in ListFavoris)
                {
                    if (item.idMovie == movie.id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    
}
