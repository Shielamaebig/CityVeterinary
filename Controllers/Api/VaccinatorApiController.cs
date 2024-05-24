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
    public class VaccinatorApiController : ControllerBase
    {
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;

        public VaccinatorApiController(ApplicationDataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("getVaccinators")]
        public async Task<ActionResult<List<Vaccinator>>> GetVaccinators()
        {
            var vaxinator = await _db.Vaccinators.ToListAsync();
            return Ok(vaxinator.OrderBy(x=>x.FullName));
        }
        [HttpGet]
        [Route("getbyIdVaxinator/{id}")]
        public async Task<ActionResult> GetbyIdVaxcinator(int id)
        {
            var vaxinatorbyId = await _db.Vaccinators.FirstOrDefaultAsync(x=>x.Id == id);
            if (vaxinatorbyId == null)
            {
                return NotFound();
            }
            return Ok(vaxinatorbyId);
        }
        [HttpPost]
        [Route("PostVaccinator")]
        public async Task<ActionResult> PostVaccinator(
            string fullName
        )
        {
            if (_db.Vaccinators.Any(x=>x.FullName == null || x.FullName == fullName)) 
            {
                return BadRequest("Vaccinator Already Exist");
            }


              _db.Vaccinators.Add(new Models.Vaccinator()
            {
                DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
                FullName = fullName,
                
            });

            await _db.SaveChangesAsync();
            return Ok("200");
        }
        [HttpPut]
        [Route("putVaccinator/{id}")]
        public async Task<ActionResult> PutVaccinator(
            int id,
            string fullName
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vaxinatorById = await _db.Vaccinators.SingleOrDefaultAsync(x => x.Id == id);

            if (vaxinatorById == null)
            {
                return NotFound();
            }

            vaxinatorById.FullName = fullName;
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpDelete]
        [Route("deleteVaccinator/{id}")]
        public async Task<ActionResult> DeleteType(int id)
        {
            var deleteVaccinator = await _db.Vaccinators.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteVaccinator == null)
            {
                return NotFound();
            }
            _db.Vaccinators.Remove(deleteVaccinator);
            await _db.SaveChangesAsync();
            return Ok("200");
        }


    }
}