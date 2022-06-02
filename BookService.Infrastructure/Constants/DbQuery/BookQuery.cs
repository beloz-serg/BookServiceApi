namespace BookService.Infrastructure.Constants.DbQuery
{
    public class BookQuery
    {
        public class Select
        {
            public const string All = @"SELECT * FROM Books";
            public const string ById = @"SELECT * FROM Books WHERE BookId = @BookId";
        }

        public class Insert
        {
            public const string One =
                @"INSERT INTO Books (AuthorId, Title, Img, Price) VALUES (@AuthorId, @Title, @Img, @Price)";
        }

        public class Update
        {
            public const string One =
                @"UPDATE Books SET AuthorId = @AuthorId, Title = @Title, Img = @Img, Price = @Price  WHERE BookId = @BookId";
        }

        public class Delete
        {
            public const string ById = @"DELETE FROM Books WHERE BookId = @BookId";
        }
    }
}
