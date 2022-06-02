namespace BookService.Domain.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
    }
}
