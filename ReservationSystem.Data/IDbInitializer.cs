using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Data
{
    public interface IDbInitializer
    {
        void CreateDatabase();
        void SeedData(string filePath);
    }
}
