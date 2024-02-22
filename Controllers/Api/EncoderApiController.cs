using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CityVeterinary.DataContext;
using CityVeterinary.Dto;
using CityVeterinary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityVeterinary.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class EncoderApiController : ControllerBase
    {
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;
        public EncoderApiController(ApplicationDataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("postEncoder")]
        public async Task<ActionResult> PostEncoder([FromBody] CityVetEncoderDto cityVetEncoderDto)
        {
            var ncdr = _mapper.Map<CityVetEncoderDto, CityVetEncoder>(cityVetEncoderDto);
            if (_db.Baranggays.Any(x => x.BaranggayName == ncdr.EncoderName || x.BaranggayName == null))
            {
                return BadRequest("Encoder Already Exist");
            }
            ncdr.EncoderName = cityVetEncoderDto.EncoderName;
            ncdr.DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
            _db.CityVetEncoders.Add(ncdr);
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpGet]
        [Route("getEncoder")]
        public async Task<ActionResult<List<CityVetEncoder>>> GetEncoder()
        {
            var ncdr = await _db.CityVetEncoders.ToListAsync();
            return Ok(ncdr.OrderByDescending(x => x.Id));
        }

        [HttpGet]
        [Route("getEncoderbyId/{id}")]
        public async Task<ActionResult> GetEnccoderById(int id)
        {
            var ncdrby = await _db.CityVetEncoders.FirstOrDefaultAsync(x => x.Id == id);
            if (ncdrby == null)
            {
                return NotFound();
            }
            return Ok(ncdrby);
        }

        [HttpPut]
        [Route("putEncoder/{id}")]
        public async Task<ActionResult> PutEncoder([FromBody] CityVetEncoderDto cityVetEncoderDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ncdrs = await _db.CityVetEncoders.SingleOrDefaultAsync(x => x.Id == id);
            if (ncdrs == null)
            {
                return NotFound();
            }
            cityVetEncoderDto.EncoderName = ncdrs.EncoderName;

            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpDelete]
        [Route("deleteEncoder/{id}")]
        public async Task<ActionResult> DeleteEncoder(int id)
        {
            var deleteEncoder = await _db.CityVetEncoders.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteEncoder == null)
            {
                return NotFound();
            }
            _db.CityVetEncoders.Remove(deleteEncoder);
            await _db.SaveChangesAsync();
            return Ok("200");
        }
    }
}