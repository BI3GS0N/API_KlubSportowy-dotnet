using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_KlubSportowy.Models;
using API_KlubSportowy.Interfaces;

namespace API_KlubSportowy.Controllers
{
    [Route("api/Fizjoterapeuci")]
    [ApiController]
    public class FizjoterapeuciController : ControllerBase
    {
        IFizjoterapeuciRepository fizjoterapeuciRepository;

        public FizjoterapeuciController(IFizjoterapeuciRepository _fizjoterapeuciRepository)
        {
            fizjoterapeuciRepository = _fizjoterapeuciRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Fizjoterapeuci> fizjoterapeuci = fizjoterapeuciRepository.GetAll();
            if (fizjoterapeuci.Any() == false)
            {
                return NoContent();
            }
            return Ok(fizjoterapeuci);
        }

        [HttpGet("{FizjoterapeuciId}")]
        public IActionResult Get(int FizjoterapeuciId)
        {
            Fizjoterapeuci fizjoterapeuci = fizjoterapeuciRepository.Get(FizjoterapeuciId);
            if (fizjoterapeuci == null)
                return NoContent();

            return Ok(fizjoterapeuci);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Fizjoterapeuci fizjoterapeuci)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newFizjoterapeuci = fizjoterapeuciRepository.Post(fizjoterapeuci);
            return CreatedAtAction(nameof(Get),
                                   new { FizjoterapeuciId = newFizjoterapeuci.IdFizjoterapeuta },
                                   newFizjoterapeuci);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Fizjoterapeuci fizjoterapeuci)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedFizjoterapeuci = fizjoterapeuciRepository.Put(fizjoterapeuci);
            return Ok(updatedFizjoterapeuci);
        }
        [HttpDelete("{FizjoterapeuciId}")]
        public IActionResult Delete(int FizjoterapeuciId)
        {
            var deletedFizjoterapeuci = fizjoterapeuciRepository.Delete(FizjoterapeuciId);

            if (deletedFizjoterapeuci == null)
                return NoContent();

            return Ok(deletedFizjoterapeuci);
        }
 
    }
}
