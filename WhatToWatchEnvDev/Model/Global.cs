using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatToWatchEnvDev.Model
{
    public class Global
    {
        private static readonly Global instance = new Global();
        public static Global Instance
        {
            get
            {
                return instance;
            }
        }
        private Global()
        {
        }

        public User GlobalUser { get; set; }

        public Boolean IsUserEmpty ()
        {
            return (this.GlobalUser == null);
        }
    }
}
