using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_KlubSportowy.Interfaces;
using API_KlubSportowy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_KlubSportowy.Controllers
{
    [Route("api/Zawodnicy")]
    [ApiController]
    public class ZawodnicyController : ControllerBase
    {
        IZawodnicyRepository zawodnicyRepository;

        public ZawodnicyController(IZawodnicyRepository _zawodnicyRepository) 
        {
            zawodnicyRepository = _zawodnicyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Zawodnicy> zawodnicy = zawodnicyRepository.GetAll();
            if (zawodnicy.Any() == false)
                return NoContent();
            return Ok(zawodnicy);
        }

        [HttpGet("{ZawodnikId}")]
        public IActionResult Get(int ZawodnikId)
        {
            Zawodnicy zawodnik = zawodnicyRepository.Get(ZawodnikId);
            if (zawodnik == null)
                return NoContent();
            return Ok(zawodnik);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Zawodnicy zawodnik)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newZawodnik = zawodnicyRepository.Post(zawodnik);
            return CreatedAtAction(nameof(Get),
                                   new { ZawodnikId = newZawodnik.IdZawodnik },
                                   newZawodnik);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Zawodnicy zawodnik)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedZawodnik = zawodnicyRepository.Put(zawodnik);
            return Ok(updatedZawodnik);
        }

        [HttpDelete("{ZawodnikId}")]
        public IActionResult Delete(int ZawodnikId)
        {
            var deletedZawodnik = zawodnicyRepository.Delete(ZawodnikId);
            if (deletedZawodnik == null)
                return NoContent();

            return Ok(deletedZawodnik);
        }
    }
}
