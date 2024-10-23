using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationSystem.Core.Models;

namespace ReservationSystem.Data.Repositories.Impl
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        private ReservationSystemContext _context;
        public ContactTypeRepository(ReservationSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ContactType>> GetContactTypes()
        {
            return await _context.ContactType.ToListAsync();
        }
        public bool ContactTypeExists(int id)
        {
            return _context.ContactType.Any(c => c.Id == id);
        }
    }
}
