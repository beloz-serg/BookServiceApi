namespace BookService.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get;}
        IBookRepository BookRepository { get; }
        IBookDataRepository BookDataRepository { get; }
    }
}
