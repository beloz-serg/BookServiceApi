﻿namespace BookService.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public decimal Price { get; set; }
    }
}
