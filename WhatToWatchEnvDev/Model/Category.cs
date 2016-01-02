using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    class Category
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("name")]
        public String name { get; set; }

        public Category ()
        {

        }

        public Category(int id, String name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
