using Project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Views.Converters
{
    class AddressConverter : AbstractConverter
    {
        public static string ConvertAddressToString(AddressDTO address)
            => string.Join(" ", 
                address.Number,
                address.Street,
                address.City,
                address.Country,
                address.PostCode
                );

        public static IList<string> ConvertAddressListToStringList(IList<AddressDTO> addresses)
            => ConvertEntityListToViewList(addresses, ConvertAddressToString);
    }
}
