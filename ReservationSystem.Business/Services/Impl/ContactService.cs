using FluentValidation.Results;
using ReservationSystem.Business.Validation;
using ReservationSystem.Core.Models;
using ReservationSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Business.Services.Impl
{
    public class ContactService: IContactService
    {
        private IContactRepository _contactRepository;
        private IContactTypeService _contactTypeService;
        private ContactValidator validator;
        public ContactService(IContactRepository contactRepository, IContactTypeService contactTypeService)
        {
            _contactRepository = contactRepository;
            _contactTypeService = contactTypeService;
            validator = new ContactValidator();
        }
        public async Task<Contact> Add(Contact contact)
        {
            ValidationResult results = validator.Validate(contact);
            if(!results.IsValid)
                throw new ArgumentException(results.Errors[0].ErrorMessage);

            if (ContactExists(contact.Name))
                throw new ArgumentException("A contact with that name already exists.");

            if(!_contactTypeService.ContactTypeExists(contact.ContactTypeId))
                throw new ArgumentException("Couldn't find the specified contact type.");

            return await _contactRepository.Add(contact);
        }

        public async Task Delete(Contact contact)
        {
            await _contactRepository.Delete(contact);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactRepository.GetContacts();
        }
        public async Task<Contact> GetContactById(int id)
        {
            return await _contactRepository.GetContactById(id);
        }
        public async Task<Contact> GetContactByName(string name)
        {
            return await _contactRepository.GetContactByName(name);
        }

        public void Update(Contact contact)
        {
            ValidationResult results = validator.Validate(contact);
            if (!results.IsValid)
                throw new ArgumentException(results.Errors[0].ErrorMessage);

            if (!_contactTypeService.ContactTypeExists(contact.ContactTypeId))
                throw new ArgumentException("Couldn't find the specified contact type.");

            _contactRepository.Update(contact);
        }

        public bool ContactExists(int id)
        {
            return _contactRepository.ContactExists(id);
        }

        public bool ContactExists(string name)
        {
            return _contactRepository.ContactExists(name);
        }

        public async Task Save()
        {
            await _contactRepository.Save();
        }
    }
}
