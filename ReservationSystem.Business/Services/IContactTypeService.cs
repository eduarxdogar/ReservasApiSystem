using ReservationSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Business.Services
{
    public interface IContactTypeService
    {
        Task<IEnumerable<ContactType>> GetContactTypes();
        bool ContactTypeExists(int id);
    }
}
