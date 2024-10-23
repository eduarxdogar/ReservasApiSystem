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
    public class ContactTypesController : ControllerBase
    {
        private readonly IContactTypeService _service;

        public ContactTypesController(IContactTypeService service)
        {
            _service = service;
        }

        // GET: api/ContactTypes
        [HttpGet]
        public async Task<IEnumerable<ContactType>> GetContactType()
        {
            return await _service.GetContactTypes();
        }
    }
}
