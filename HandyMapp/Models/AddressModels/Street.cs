using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HandyMapp.Models.Navigation;

namespace HandyMapp.Models.Addresmoddels
{
    public partial class Street
    {
        public Street()
        {
            Address = new HashSet<Address>();
        }
        
        public int Id { get; set; }
        public string LongName { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
