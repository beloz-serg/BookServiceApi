namespace BookService.Domain.Dto
{
    public class BookDataDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
    }
}
