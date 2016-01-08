using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        public Category ()
        {

        }

        public Category(int id, String name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
