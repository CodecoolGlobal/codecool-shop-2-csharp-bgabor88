using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        public int Id { get; set; }

        public IEnumerable<Item> ItemCollection = new List<Item>();

        public PaymentInfo PaymentInfo { get; set; }

        public decimal Total { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string FullNameShipping { get; set; }

        public string EmailShipping { get; set; }

        public string AddressShipping { get; set; }

        public string CityShipping { get; set; }

        public string StateShipping { get; set; }

        public string ZipShipping { get; set; }
    }
}
