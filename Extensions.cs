using TestAPI.Dtos;
using TestAPI.Entities;

namespace TestAPI
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                id = item.id,
                name = item.name,
                price = item.price,
                createdDate = item.createdDate
            };
        }
    }
}
