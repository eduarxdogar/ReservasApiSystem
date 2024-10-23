using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Business.Services
{
    public interface IDbInitializeService
    {
        void CreateDatabase();
        void SeedData(string filePath);
    }
}
