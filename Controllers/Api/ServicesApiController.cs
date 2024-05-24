using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityVeterinary.DataContext;
using CityVeterinary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityVeterinary.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesApiController : ControllerBase
    {
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;

        public ServicesApiController(ApplicationDataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("getServices")]
        public async Task<ActionResult<List<Services>>> GetpetTypes()
        {
            var Service = await _db.Services.ToListAsync();
            return Ok(Service.OrderBy(x => x.Service));
        }

        [HttpPost]
        [Route("PostServices")]
        public async Task<ActionResult> PostService(
            string dateAdded,
            string service)
        {
            if (_db.Services.Any(x => x.Service == null || x.Service == service))
            {
                return BadRequest("Breed Name Type Already Exist");
            }

            _db.Services.Add(new Models.Services()
            {
                Service = service,
                DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
            });

            await _db.SaveChangesAsync();
            return Ok("200");
        }
        [HttpGet]
        [Route("getServicebyId/{id}")]
        public async Task<ActionResult> GetbyService(int id)
        {
            var sbyId = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (sbyId == null)
            {
                return NotFound();
            }
            return Ok(sbyId);
        }

        [HttpPut]
        [Route("putServices/{id}")]
        public async Task<ActionResult> PutService(
          string service,
          int id
      )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var servicebyId = await _db.Services.SingleOrDefaultAsync(x => x.Id == id);

            if (servicebyId == null)
            {
                return NotFound();
            }

            servicebyId.Service = service;
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpDelete]
        [Route("deleteService/{id}")]
        public async Task<ActionResult> DeleteType(int id)
        {
            var deleteService = await _db.Services.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteService == null)
            {
                return NotFound();
            }
            _db.Services.Remove(deleteService);
            await _db.SaveChangesAsync();
            return Ok("200");
        }
    }
}