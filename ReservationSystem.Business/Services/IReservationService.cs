using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationSystem.Core.Models;

namespace ReservationSystem.Business.Services
{
    public interface IReservationService
    {
        Task<Reservation> Add(Reservation reservation);

        Task Rate(Reservation reservation);

        Task Delete(Reservation reservation);

        Task<IEnumerable<Reservation>> GetReservations();

        Task<Reservation> GetReservationById(int id);

        void Update(Reservation reservation);

        Task Save();

        bool ReservationExists(int id);
    }
}
