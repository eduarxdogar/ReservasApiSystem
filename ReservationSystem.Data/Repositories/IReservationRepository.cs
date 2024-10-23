using System.Collections.Generic;
using System.Threading.Tasks;
using ReservationSystem.Core.Models;

namespace ReservationSystem.Data.Repositories
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetReservations();
        Task<Reservation> GetReservationById(int id);
        bool ReservationExists(int id);
        Task<Reservation> Add(Reservation reservation);
        Task Rate(Reservation reservation);
        Task Delete(Reservation reservation);
        void Update(Reservation reservation);
        Task Save();
    }
}
