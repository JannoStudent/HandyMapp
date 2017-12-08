using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandyMapp.Models.Addresmoddels
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }
        
        public int Id { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
