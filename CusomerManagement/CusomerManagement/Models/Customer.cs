using System;

namespace CusomerManagement.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Forename { get; set; }
		public string Surname { get; set; }
		public string EmailAdress { get; set; }
		public string MobileNo { get; set; }
		public Boolean IsActive { get; set; }
		public List<Address> Addresses { get; set; }
	}
}

