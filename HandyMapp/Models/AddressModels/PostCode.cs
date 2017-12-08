using System.Collections.Generic;

namespace HandyMapp.Models.AddressModels
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
