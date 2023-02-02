using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Context
{
    public class DataContextTest
    {
        public DataContext _context;

        public DataContextTest()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DataContextTest")
                .Options;

            _context = new DataContext(options);
        }
    }
}
