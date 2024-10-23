using ReservationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Business.Services.Impl
{
    public class DbInitializeService : IDbInitializeService
    {
        private IDbInitializer _dbInitializer;
        public DbInitializeService(IDbInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
        }

        public void CreateDatabase()
        {
            _dbInitializer.CreateDatabase();
        }

        public void SeedData(string filePath)
        {
            _dbInitializer.SeedData(filePath);
        }
    }
}
