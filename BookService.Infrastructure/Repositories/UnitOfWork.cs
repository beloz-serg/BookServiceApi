using BookService.Application.Interfaces.Repositories;

namespace BookService.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository AuthorRepository { get; }
        public IBookRepository BookRepository { get; }
        public IBookDataRepository BookDataRepository { get; }

        public UnitOfWork(IAuthorRepository authorRepository, IBookRepository bookRepository,
            IBookDataRepository bookDataRepository)
        {
            AuthorRepository = authorRepository;
            BookRepository = bookRepository;
            BookDataRepository = bookDataRepository;
        }
    }
}
