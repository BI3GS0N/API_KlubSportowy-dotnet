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
    [Route("api/Zespoly")]
    [ApiController]
    public class ZespolyController : ControllerBase
    {
        IZespolyRepository zespolyRepository;

        public ZespolyController(IZespolyRepository _zespolyRepository)
        {
            zespolyRepository = _zespolyRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Zespoly> zespoly = zespolyRepository.GetAll();
            if (zespoly.Any() == false)
                return NoContent();
            return Ok(zespoly);
        }

        [HttpGet("{ZespolId}")]
        public IActionResult Get(int ZespolId)
        {
            Zespoly zespol = zespolyRepository.Get(ZespolId);
            if (zespol == null)
                return NoContent();
            return Ok(zespol);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Zespoly zespol)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newZespol = zespolyRepository.Post(zespol);
            return CreatedAtAction(nameof(Get),
                                   new { ZespolId = newZespol.IdZespol },
                                   newZespol);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Zespoly zespol)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedZespol = zespolyRepository.Put(zespol);
            return Ok(updatedZespol);
        }

        [HttpDelete("{ZespolId}")]
        public IActionResult Delete(int ZespolId)
        {
            var deletedZespol = zespolyRepository.Delete(ZespolId);
            if (deletedZespol == null)
                return NoContent();

            return Ok(deletedZespol);
        }

    }
}
