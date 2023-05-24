namespace Data.IRepositories
{
    public interface IAllRepositories<T>
    {
        Task<IEnumerable<T>> GetAllItem();
        Task<bool> CreateItem(T item);
        Task<bool> DeleteItem(T item);
        Task<bool> UpdateItem(T item);
    }
}
