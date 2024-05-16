using Microsoft.AspNetCore.Mvc;
using TeaProduction.Business.DTOs;
using TeaProduction.Business.Interfaces;

namespace TeaProduction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackTeaController : ControllerBase
    {
        private readonly IBlackTeaInterface blackTeaInterface;

        public BlackTeaController(IBlackTeaInterface blackTeaInterface)
        {
            this.blackTeaInterface = blackTeaInterface;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var blackTeaDtos = blackTeaInterface.GetAll();
            return Ok(blackTeaDtos);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var blackTeaDto = blackTeaInterface.GetById(id);
            if (blackTeaDto == null)
            {
                return NotFound();
            }
            return Ok(blackTeaDto);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BlackTeaDto blackTeaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var blackTea = blackTeaInterface.Add(blackTeaDto);
            return CreatedAtAction("Get", new { id = blackTea.Id }, blackTea);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var blackTeaDto = blackTeaInterface.GetById(id);
            if (blackTeaDto == null)
            {
                return NotFound();
            }
            blackTeaInterface.Delete(id);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(BlackTeaDto blackTeaDto)
        {
            var blackTea = blackTeaInterface.Update(blackTeaDto);
            if (blackTea == null)
            {
                return NotFound();
            }
            return Ok(blackTea);
        }
    }
}
