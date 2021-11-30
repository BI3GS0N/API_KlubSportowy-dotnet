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
    [Route("api/Kontuzje")]
    [ApiController]
    public class KontuzjeController : ControllerBase
    {
        IKontuzjeRepository kontuzjeRepository;

        public KontuzjeController(IKontuzjeRepository _kontuzjeRepository)
        {
            kontuzjeRepository = _kontuzjeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Kontuzje> kontuzje = kontuzjeRepository.GetAll();
            if (kontuzje.Any() == false)
                return NoContent();
            return Ok(kontuzje);
        }

        [HttpGet("{KontuzjaId}")]
        public IActionResult Get(int KontuzjaId)
        {
            Kontuzje kontuzja = kontuzjeRepository.Get(KontuzjaId);
            if (kontuzja == null)
                return NoContent();

            return Ok(kontuzja);
        }

        [HttpDelete("{KontuzjaId}")]
        public IActionResult Delete(int kontuzjaId)
        {
            var deletedKontuzja = kontuzjeRepository.Delete(kontuzjaId);
            if (deletedKontuzja == null)
                return NoContent();
            return Ok(deletedKontuzja);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Kontuzje kontuzja)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newKontuzja = kontuzjeRepository.Post(kontuzja);
            return CreatedAtAction(nameof(Get),
                new { KontuzjaId = newKontuzja.IdKontuzja },
                newKontuzja);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Kontuzje kontuzja)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedKontuzja = kontuzjeRepository.Put(kontuzja);
            return Ok(updatedKontuzja);
        }


    }
}
