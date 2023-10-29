using System;
using System.ComponentModel.DataAnnotations;
using CustomerManagement.Validators;

namespace CustomerManagement.Models
{
	public class Address : AuditEntity
	{
		public int Id { get; set; }
        [Required]
        [StringLength(Constants.ADDRESS_ADDRESS_LINE_1_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string AddressLine1 { get; set; }
        [StringLength(Constants.ADDRESS_ADDRESS_LINE_2_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(Constants.ADDRESS_TOWN_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Town { get; set; }
        [StringLength(Constants.ADDRESS_COUNTRY_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Country { get; set; }
        [Required]
        [StringLength(Constants.ADDRESS_POSTCODE_MAX_LENGTH, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 0)]
        public string Postcode { get; set; }
        public bool IsMain { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Address address &&
                   CreatedDate == address.CreatedDate &&
                   UpdatedDate == address.UpdatedDate &&
                   Id == address.Id &&
                   AddressLine1 == address.AddressLine1 &&
                   AddressLine2 == address.AddressLine2 &&
                   Town == address.Town &&
                   Country == address.Country &&
                   Postcode == address.Postcode &&
                   IsMain == address.IsMain;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(CreatedDate);
            hash.Add(UpdatedDate);
            hash.Add(Id);
            hash.Add(AddressLine1);
            hash.Add(AddressLine2);
            hash.Add(Town);
            hash.Add(Country);
            hash.Add(Postcode);
            hash.Add(IsMain);
            return hash.ToHashCode();
        }
    }
}

