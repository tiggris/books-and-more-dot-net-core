namespace BooksAndMore.Catalogue.Domain.Common.Model
{
    public interface IEntity<T>: IEntity
    {
        T Id { get; }
    }
}