namespace TestAPI.Dtos
{
    public record ItemDto
    {

        public Guid id { get; init; }

        public string name { get; init; }

        public int price { get; init; }

        public DateTimeOffset createdDate { get; set; }
    }
}
