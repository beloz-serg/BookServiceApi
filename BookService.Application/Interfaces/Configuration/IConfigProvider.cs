namespace BookService.Application.Interfaces.Configuration
{
    public interface IConfigProvider
    {
        bool IsDevelopment { get; }
        string Get(string key);
        string Get(string sectionName, string key);
        string GetConnectionString();
    }
}
