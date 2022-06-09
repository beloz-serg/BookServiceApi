namespace BookService.Infrastructure.Constants.DbQuery
{
    public class CartQuery
    {
        public class Insert
        {
            public const string One =
                @"INSERT INTO CartItems (Book, Price, UserEmail) VALUES (@Book, @Price, @UserEmail)";
        }

        public class Select
        {
            public const string All = @"SELECT * FROM CartItems";

            public const string ById = @"SELECT * FROM CartItems WHERE CartItemId = @CartItemId";
        }

        public class Update
        {
            public const string One =
                @"UPDATE CartItems SET Book = @Book, Price = @Price, UserEmail = @UserEmail WHERE CartItemId = @CartItemId";
        }
         
        public class Delete
        {
            public const string One = @"DELETE FROM CartItems WHERE CartItemId = @CartItemId";
        }
    }
}
