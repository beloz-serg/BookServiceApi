namespace BookService.Domain.Entities
{
    public class BookData
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string ImgSrc { get; set; }
        public decimal BookPrice { get; set; }
    }
}
