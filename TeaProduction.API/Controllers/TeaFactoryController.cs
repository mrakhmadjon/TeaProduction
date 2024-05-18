using Microsoft.AspNetCore.Mvc;
using TeaProduction.Business.DTOs;
using TeaProduction.Business.Enums;
using TeaProduction.Business.TeaFactory;

namespace TeaProduction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeaFactoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult OrderForTeaProduction(string teaType, int packageCount)
        {
            teaType = teaType.ToLower();
            TeaType teaTypeForProduction = teaType switch
            {
                "black" => TeaType.BlackTea,
                "green" => TeaType.GreenTea,
                "herbal" => TeaType.HerbalTea,
                _ => 0

            };
            if (teaTypeForProduction == 0)
            {
                return BadRequest("This kind of tea does not exist");
            }


            if (teaTypeForProduction == TeaType.BlackTea)
            {
                TeaFactoryAbstract<BlackTeaDto> teaFactory = new BlackTeaFactory();
                teaFactory.Produce(packageCount);
            }
            else if (teaTypeForProduction == TeaType.GreenTea)
            {
                TeaFactoryAbstract<GreenTeaDto> teaFactory = new GreenTeaFactory();
                teaFactory.Produce(packageCount);
            }
            else
            {
                TeaFactoryAbstract<HerbalTeaDto> teaFactory = new HerbalTeaFactory();
                teaFactory.Produce(packageCount);
            }

            return Ok();

        }
    }
}
