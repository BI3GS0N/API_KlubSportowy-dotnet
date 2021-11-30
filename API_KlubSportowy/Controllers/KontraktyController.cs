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
    [Route("api/Kontrakty")]
    [ApiController]
    public class KontraktyController : ControllerBase
    {
        IKontraktyRepository kontraktyRepository;
        public KontraktyController(IKontraktyRepository _kontraktyRepository)
        {
            kontraktyRepository = _kontraktyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Kontrakty> kontrakty = kontraktyRepository.GetAll();
            if (kontrakty.Any() == false)
            {
                return NoContent();
            }

            return Ok(kontrakty);
        }

        [HttpGet("{KontraktyId}")]
        public IActionResult Get(int kontraktId)
        {
            Kontrakty kontrakt = kontraktyRepository.Get(kontraktId);
            if (kontrakt == null)
            {
                return NoContent();
            }
            return Ok(kontrakt);
        }

        [HttpDelete("{kontraktId}")]
        public IActionResult Delete(int kontraktId) 
        {
            var deletedKontrakt = kontraktyRepository.Delete(kontraktId);
            if (deletedKontrakt == null)
            {
                return NoContent();
            }
            return Ok(deletedKontrakt);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Kontrakty kontrakt) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var newKontrakt = kontraktyRepository.Post(kontrakt);
            return CreatedAtAction(nameof(Get),
                new { KontraktId = newKontrakt.IdKontrakt },
                newKontrakt);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Kontrakty kontrakt)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            var updatedKontrakt = kontraktyRepository.Put(kontrakt);
            return Ok(updatedKontrakt);
        }
    }
}
