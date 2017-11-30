﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handy_Mapp.Models.Addresmoddels
{
    public partial class Province
    {
        public Province()
        {
            Address = new HashSet<Address>();
        }
        
        public int Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
