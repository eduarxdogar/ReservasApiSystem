using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Core.Models;
using ReservationSystem.Business.Services;

namespace ReservationSystem.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _service;

        public ReservationsController(IReservationService service)
        {
            _service = service;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<IEnumerable<Reservation>> GetReservation()
        {
            return await _service.GetReservations();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _service.GetReservationById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            try
            {
                await _service.Add(reservation);
            }
            catch(Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                else
                    return Problem("Error creating reservation", "Reservations Controller", 500);
            }

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // POST: api/Reservations/Rate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Rate")]
        public async Task<ActionResult<double>> RateReservation(Reservation reservation)
        {
            try
            {
                await _service.Rate(reservation);
                Reservation rated = await _service.GetReservationById(reservation.Id);
                return rated.Ranking;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                else
                    return Problem("Error rating reservation", "Reservations Controller", 500);
            }

            //return NoContent();
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(reservation);
            }
            catch(Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                else
                    return Problem("Error updating reservation", "Reservations Controller", 500);
            }

            try
            {
                await _service.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _service.GetReservationById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            await _service.Delete(reservation);

            return NoContent();
        }
    }
}
