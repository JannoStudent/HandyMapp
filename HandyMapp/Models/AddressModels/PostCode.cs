using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Handy_Mapp.Models.Addresmoddels
{
    public partial class PostCode
    {
        public PostCode()
        {
            Address = new HashSet<Address>();
        }
        
        public int Id { get; set; }
        public string PostCode1 { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
