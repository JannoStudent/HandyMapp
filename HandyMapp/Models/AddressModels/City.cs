using System.Collections.Generic;

namespace HandyMapp.Models.AddressModels
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
