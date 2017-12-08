using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HandyMapp.Models.AddressModels
{
    public partial class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
        }

        public int Id { get; set; }
        [Required]
        public string LongName { get; set; }
        public string ShortName { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
