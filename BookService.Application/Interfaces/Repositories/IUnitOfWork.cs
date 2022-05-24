namespace BookService.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; set; }
        IBookRepository BookRepository { get; set; }
        IBookDataRepository BookDataRepository { get; set; }
    }
}
