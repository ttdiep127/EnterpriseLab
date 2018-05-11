namespace CRMV2
{
    internal class Address
    {
        public string Place { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public Address(string place, string email, string phoneNumber)
        {
            Place = place;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}