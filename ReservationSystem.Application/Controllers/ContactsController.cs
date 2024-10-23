using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Business.Services;
using ReservationSystem.Core.Models;

namespace ReservationSystem.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IEnumerable<Contact>> GetContact()
        {
            return await _service.GetContacts();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _service.GetContactById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // POST: api/Contacts/getbyname
        [HttpPost]
        [Route("getbyname")]
        public async Task<ActionResult<Contact>> GetContactByName(Contact contact)
        {
            var foundContact = await _service.GetContactByName(contact.Name);

            if (foundContact == null)
            {
                return NotFound();
            }

            return foundContact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(contact);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                else
                    return Problem("Error creating reservation", "Reservations Controller", 500);
            }

            try
            {
                await _service.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_service.ContactExists(id))
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

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostContact(Contact contact)
        {
            try
            {
                await _service.Add(contact);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    return BadRequest(ex.Message);
                else
                    return Problem("Error creating contact","Contacts Controller",500);
            }

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _service.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }

            await _service.Delete(contact);

            return NoContent();
        }
    }
}
