using System.ComponentModel.DataAnnotations;

namespace TestAPI.Dtos
{
    public record CreateItemDto
    {

        [Required]
        public string name { get; init; }

        [Required]
        [Range(1,1000)]
        public int price { get; init; }
    }
}
