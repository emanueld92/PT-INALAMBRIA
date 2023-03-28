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
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param userName="item"></param>
    /// <param password="item"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
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



            if (order.Count() > 0)
            {
                var result = JsonConvert.SerializeObject(order);

                return StatusCode(StatusCodes.Status200OK,result);
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error: Conjuto de fichas no validas" });
            } 

        }
    }
}
