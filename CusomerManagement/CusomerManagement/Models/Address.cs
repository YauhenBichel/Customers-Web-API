using System;

namespace CusomerManagement.Models
{
	public class Address
	{
		public int Id { get; set; }
		public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
		public string Town { get; set; }
		public string Country { get; set; }
		public string Postcode { get; set; }

    }
}

