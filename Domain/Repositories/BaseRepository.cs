namespace Domain.Repositories
{
    public interface BaseRepository
    {
        void AddEntity<T>(T entity) where T : class;
        Task SaveChangesAsync();
        void UpdateEntity<T>(T entity) where T : class;
    }
}
