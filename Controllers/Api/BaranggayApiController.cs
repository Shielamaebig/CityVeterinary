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
        [Route("postBaranngay")]
        public async Task<ActionResult> PostBgy([FromBody] BaranggayDto baranggayDto)
        {
            var bgy = _mapper.Map<BaranggayDto, Baranggay>(baranggayDto);
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
    }
}