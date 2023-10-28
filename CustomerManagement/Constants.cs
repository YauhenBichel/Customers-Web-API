using System;
namespace CustomerManagement.Validators
{
	public sealed class Constants
	{
        private Constants()
        {

        }

        public const int CUSTOMER_TITLE_MAX_LENGTH = 20;
        public const int CUSTOMER_FORENAME_MAX_LENGTH = 50;
        public const int CUSTOMER_SURNAME_MAX_LENGTH = 50;
        public const int CUSTOMER_EMAIL_ADDRESS_MAX_LENGTH = 75;
        public const int CUSTOMER_MOBILE_NUMBER_MAX_LENGTH = 15;

        public const int ADDRESS_ADDRESS_LINE_1_MAX_LENGTH = 80;
        public const int ADDRESS_ADDRESS_LINE_2_MAX_LENGTH = 80;
        public const int ADDRESS_TOWN_MAX_LENGTH = 50;
        public const int ADDRESS_COUNTRY_MAX_LENGTH = 50;
        public const int ADDRESS_POSTCODE_MAX_LENGTH = 10;

        public const int ADDRESS_MINIMUM_AMOUNT = 1;

        public const string DATABASE_NAME = "CustomerManagement";
    }
}

