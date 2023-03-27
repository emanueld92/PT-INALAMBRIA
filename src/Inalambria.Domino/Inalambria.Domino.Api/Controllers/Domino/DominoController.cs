using Inalambria.Domino.ApplicationServices.Ordering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Inalambria.Domino.Api.Controllers.Domino
{
    [Route("api/[controller]")]
    [ApiController]
    public class DominoController : ControllerBase
    {


        private readonly IDominoServices _dominoServices;
        public DominoController(IDominoServices dominoServices)
        {
            _dominoServices = dominoServices;
        }


        [Authorize]
        [HttpPost("GetDomino")]
        public IActionResult OrderingDomino([FromBody] List<string> values)
        {

           

            var order=_dominoServices.OrderDomino(values);

            var result = JsonConvert.SerializeObject(order);

            return StatusCode(StatusCodes.Status200OK,result);
        }
    }
}
