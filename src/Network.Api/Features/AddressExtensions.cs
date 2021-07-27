using Network.Api.Models;

namespace Network.Api.Features
{
    public static class AddressExtensions
    {
        public static AddressDto ToDto(this Address address)
        {
            return new()
            {
                Street = address.Street,
                City = address.City,
                Province = address.Province,
                PostalCode = address.PostalCode
            };
        }
    }
}
