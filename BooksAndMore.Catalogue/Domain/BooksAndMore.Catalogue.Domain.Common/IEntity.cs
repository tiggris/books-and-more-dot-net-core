namespace BooksAndMore.Catalogue.Domain.Common
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}