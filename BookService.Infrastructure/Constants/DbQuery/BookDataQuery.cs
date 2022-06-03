namespace BookService.Infrastructure.Constants.DbQuery
{
    public class BookDataQuery
    {
        public class Select
        {
            public const string All =
@"SELECT Books.BookId BookId, Books.Title BookTitle, Authors.AuthorName AuthorName, Books.Img ImgSrc, Books.Price BookPrice
FROM Books JOIN Authors ON Authors.AuthorId = Books.AuthorId";

            public const string ByBookId =
@"SELECT Books.BookId BookId, Books.Title BookTitle, Authors.AuthorName AuthorName, Books.Img ImgSrc, Books.Price BookPrice
FROM Books JOIN Authors ON Authors.AuthorId = Books.AuthorId WHERE Books.BookId = @BookId";
        }
    }
}
