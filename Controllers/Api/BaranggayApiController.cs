using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BaranggayApiController : ControllerBase
    {
        private readonly ApplicationDataContext _db;
        private readonly IMapper _mapper;


        public BaranggayApiController(ApplicationDataContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("postBaranggay")]
        public async Task<ActionResult> PostBgy([FromBody] BaranggayDto baranggayDto)
        {
            var bgy = _mapper.Map<BaranggayDto, Baranggay>(baranggayDto);
            if (_db.Baranggays.Any(x => x.BaranggayName == bgy.BaranggayName || x.BaranggayName == null))
            {
                return BadRequest("Baranggay Already Exist/ Null");
            }
            bgy.Id = baranggayDto.Id;
            bgy.DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
            bgy.BaranggayName = baranggayDto.BaranggayName;
            _db.Baranggays.Add(bgy);
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpGet]
        [Route("getBgy")]
        public async Task<ActionResult<List<Baranggay>>> GetBgys()
        {
            var bgys = await _db.Baranggays.ToListAsync();
            return Ok(bgys.OrderBy(x => x.BaranggayName));
        }
        [HttpGet]
        [Route("getBgybyId/{id}")]
        public async Task<ActionResult> GetBgyById(int id)
        {
            var bgybyId = await _db.Baranggays.FirstOrDefaultAsync(x => x.Id == id);
            if (bgybyId == null)
            {
                return NotFound();
            }
            return Ok(bgybyId);
        }

        [HttpPut]
        [Route("putBgy/{id}")]
        public async Task<ActionResult> PutEncoder([FromBody] BaranggayDto baranggayDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bgys = await _db.Baranggays.SingleOrDefaultAsync(x => x.Id == id);
            if (bgys == null)
            {
                return NotFound();
            }
            _mapper.Map(baranggayDto, bgys);
            baranggayDto.BaranggayName = bgys.BaranggayName;
            bgys.DateAdded = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt");
            await _db.SaveChangesAsync();
            return Ok("200");
        }

        [HttpDelete]
        [Route("deleteBgy/{id}")]
        public async Task<ActionResult> DeleteBgy(int id)
        {
            var deleteBgy = await _db.Baranggays.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteBgy == null)
            {
                return NotFound();
            }
            _db.Baranggays.Remove(deleteBgy);
            await _db.SaveChangesAsync();
            return Ok("200");
        }
    }
}