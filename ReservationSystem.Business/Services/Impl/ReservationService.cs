using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationSystem.Data.Repositories;
using ReservationSystem.Core.Models;
using System;
using ReservationSystem.Business.Validation;
using FluentValidation.Results;

namespace ReservationSystem.Business.Services.Impl
{
    public class ReservationService : IReservationService
    {
        private IReservationRepository _repository;
        private IContactService _contactService;
        private ReservationValidator validator;
        public ReservationService(IReservationRepository repository, IContactService contactService)
        {
            _repository = repository;
            _contactService = contactService;
            validator = new ReservationValidator();
        }
        public async Task<Reservation> Add(Reservation reservation)
        {
            ValidationResult results = validator.Validate(reservation);
            if (!results.IsValid)
                throw new ArgumentException(results.Errors[0].ErrorMessage);

            if (!_contactService.ContactExists(reservation.ContactId))
                throw new ArgumentException("Couldn't find the specified contact.");

            return await _repository.Add(reservation);
        }

        public async Task Rate(Reservation reservation)
        {
            ValidationResult results = validator.Validate(reservation);
            if (!results.IsValid)
                throw new ArgumentException(results.Errors[0].ErrorMessage);

            if (!_contactService.ContactExists(reservation.ContactId))
                throw new ArgumentException("Couldn't find the specified contact.");

            await _repository.Rate(reservation);
        }

        public async Task Delete(Reservation reservation)
        {
            await _repository.Delete(reservation);
        }

        public async Task<IEnumerable<Reservation>> GetReservations()
        {
            return await _repository.GetReservations();
        }
        public async Task<Reservation> GetReservationById(int id)
        {
            return await _repository.GetReservationById(id);
        }

        public void Update(Reservation reservation)
        {
            ValidationResult results = validator.Validate(reservation);
            if (!results.IsValid)
                throw new ArgumentException(results.Errors[0].ErrorMessage);

            if (!_contactService.ContactExists(reservation.ContactId))
                throw new ArgumentException("Couldn't find the specified contact.");

            _repository.Update(reservation);
        }
        public async Task Save()
        {
            await _repository.Save();
        }

        public bool ReservationExists(int id)
        {
            return _repository.ReservationExists(id);
        }
    }
}
