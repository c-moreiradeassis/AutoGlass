using Data.Context;
using Domain.Repositories;

namespace Data.Repositories
{
    public class BaseRepositoryImp : BaseRepository
    {
        private DataContext _dataContext;

        public BaseRepositoryImp(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddEntity<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
