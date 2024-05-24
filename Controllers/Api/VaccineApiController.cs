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
    public class VaccineApiController : ControllerBase
    {
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;

        public VaccineApiController(ApplicationDataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }


        [HttpPost]
        [Route("PostVaccine")]
        public async Task<ActionResult> PostVaccinator(
            string manufacturer,
            string lotNumber,
            string vaccineName
        ){
            if (_db.Vaccines.Any(x=>x.VaccineName == vaccineName || x.VaccineName == null)) 
            {
                return BadRequest("Vaccine Already Exist");
            }

            _db.Vaccines.Add(new Models.Vaccine()
            {
                DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
                Manufacturer = manufacturer,
                LotNumber = lotNumber,
                VaccineName = vaccineName
            });

            await _db.SaveChangesAsync();
            return Ok("200");
        }
        [HttpGet]
        [Route("GetVaccines")]
        public async Task<ActionResult<List<Vaccine>>> GetVaccines()
        {
            var vax = await _db.Vaccines.ToListAsync();
            return Ok(vax.OrderByDescending(x=>x.Id));
        }

        [HttpGet]
        [Route("getByVaccineId/{id}")]
        public async Task<ActionResult> GetbyVacId(int id)
        {
            var vaxId = await _db.Vaccines.FirstOrDefaultAsync(x => x.Id == id);
            if (vaxId == null)
            {
                return NotFound();
            }
            return Ok(vaxId);
        }
        [HttpPut]
        [Route("putVaccine/{id}")]
        public async Task<ActionResult> PutVax(
            int id,
            string manufacturer,
            string lotNumber,
            string vaccineName
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vaxById = await _db.Vaccines.SingleOrDefaultAsync(x => x.Id == id);

            if (vaxById == null)
            {
                return NotFound();
            }

            vaxById.Manufacturer = manufacturer;
            vaxById.LotNumber = lotNumber;
            vaxById.VaccineName = vaccineName;
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpDelete]
        [Route("deleteVax/{id}")]
        public async Task<ActionResult> DeleteType(int id)
        {
            var deleteVax = await _db.Vaccines.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteVax == null)
            {
                return NotFound();
            }
            _db.Vaccines.Remove(deleteVax);
            await _db.SaveChangesAsync();
            return Ok("200");
        }


    }
}