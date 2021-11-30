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
    [Route("api/Trenerzy")]
    [ApiController]
    public class TrenerzyController : ControllerBase
    {
        ITrenerzyRepository trenerzyRepository;

        public TrenerzyController(ITrenerzyRepository _trenerzyRepository)
        {
            trenerzyRepository = _trenerzyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Trenerzy> trenerzy = trenerzyRepository.GetAll();
            if (trenerzy.Any() == false)
                return NoContent();
            return Ok(trenerzy);
        }

        [HttpGet("{TrenerId}")]
        public IActionResult Get(int TrenerId)
        {
            Trenerzy trener = trenerzyRepository.Get(TrenerId);
            if (trener == null)
                return NoContent();
            return Ok(trener);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Trenerzy trener)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var newTrener = trenerzyRepository.Post(trener);
            return CreatedAtAction(nameof(Get),
                new { TrenerId = newTrener.IdTrener},
                newTrener);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Trenerzy trener)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedTrener = trenerzyRepository.Put(trener);
            return Ok(updatedTrener);
        }

        [HttpDelete("{TrenerId}")]
        public IActionResult Delete(int TrenerId)
        {
            var deletedTrener = trenerzyRepository.Delete(TrenerId);

            if (deletedTrener == null)
                return NoContent();

            return Ok(deletedTrener);
        }

    }
}
