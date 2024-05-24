using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityVeterinary.DataContext;
using CityVeterinary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityVeterinary.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinarianApiController : ControllerBase
    {
        private readonly ApplicationDataContext _db;

        public VeterinarianApiController(ApplicationDataContext db)
        {
            this._db = db;
        }
        [HttpGet]
        [Route("getVeterinarians")]
        public async Task<ActionResult<List<Vaccinator>>> GetVeterinarian()
        {
            var vets = await _db.Veterinarians.ToListAsync();
            return Ok(vets.OrderByDescending(x=>x.Id));
        }
        [HttpGet]
        [Route("getVetsbyId/{id}")]
        public async Task<ActionResult> GetByIdVets(int id)
        {
            var vetsbyId = await _db.Veterinarians.FirstOrDefaultAsync(x=>x.Id == id);
            if (vetsbyId == null)
            {
                return NotFound();
            }
            return Ok(vetsbyId);
        }
        [HttpPost]
        [Route("PostVets")]
        public async Task<ActionResult> PostVets(string vetName)
        {
            if (_db.Veterinarians.Any(x=>x.VetName == null || x.VetName == vetName))
            {
                return BadRequest("Veterinarian Already Exist");
            }

            _db.Veterinarians.Add(new Models.Veterinarian() {
                DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
                VetName = vetName,
            });
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpPut]
        [Route("putVeterinarians/{id}")]
        public async Task<ActionResult> PutVaccinator(
            int id,
            string vetName
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vetbyId = await _db.Veterinarians.SingleOrDefaultAsync(x => x.Id == id);

            if (vetbyId == null)
            {
                return NotFound();
            }

            vetbyId.VetName = vetName;
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        
        [HttpDelete]
        [Route("deleteVet/{id}")]
        public async Task<ActionResult> DeleteType(int id)
        {
            var deleteVet = await _db.Veterinarians.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteVet == null)
            {
                return NotFound();
            }
            _db.Veterinarians.Remove(deleteVet);
            await _db.SaveChangesAsync();
            return Ok("200");
        }
    }
}