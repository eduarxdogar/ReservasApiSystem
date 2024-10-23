using ReservationSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Data.Repositories
{
    public interface IContactTypeRepository
    {
        Task<IEnumerable<ContactType>> GetContactTypes();
        bool ContactTypeExists(int id);
    }
}
