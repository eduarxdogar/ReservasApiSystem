using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Business.Services;
using ReservationSystem.Core.Models;
using ReservationSystem.Data.Repositories;

namespace ReservationSystem.Business.Services.Impl
{
    public class ContactTypeService : IContactTypeService
    {
        private IContactTypeRepository _repository;
        public ContactTypeService(IContactTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ContactType>> GetContactTypes()
        {
            return await _repository.GetContactTypes();
        }
        public bool ContactTypeExists(int id)
        {
            return _repository.ContactTypeExists(id);
        }
    }
}
