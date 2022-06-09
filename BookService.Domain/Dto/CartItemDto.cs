namespace BookService.Domain.Dto
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public string Book { get; set; }
        public decimal Price { get; set; }
        public string UserEmail { get; set; }
    }
}
