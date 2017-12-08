using System.Collections.Generic;

namespace HandyMapp.Models.AddressModels
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
