using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    class ImdbResponse
    {
        [JsonProperty("genres")]
        public List<Category> genres { get; set; }

        
        public ImdbResponse(List<Category> genres)
        {
            this.genres = genres;
        }
    }
}
