namespace BookService.Infrastructure.Constants.DbQuery
{
    public class AuthorQuery
    {
        public class Select
        {
            public const string All = @"SELECT * FROM Authors";
            public const string ById = @"SELECT * FROM Authors WHERE AuthorId = @AuthorId";
        }

        public class Insert
        {
            public const string One =
                @"INSERT INTO Authors (AuthorName) VALUES (@AuthorName)";
        }

        public class Update
        {
            public const string One =
                @"UPDATE Authors SET AuthorName = @AuthorName WHERE AuthorId = @AuthorId";
        }

        public class Delete
        {
            public const string ById = @"DELETE FROM Authors WHERE AuthorId = @AuthorId";
        }
    }
}
