using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using FruitVice_Services_Core.Contracts;

namespace FruityVice_API.Controllers
{

        [Route("api/FruityVice")]
        [ApiController]
        public class FruityViceController : Controller
        {
            protected readonly IFruityViceService _fruityViceService;

            public FruityViceController(IFruityViceService fruityViceService)
            {
                _fruityViceService = fruityViceService;
            }

            [HttpGet("GetAllFruitsCollection")]
            public async Task<ActionResult> GetAllFruitsCollection()
            {
                try
                {
                    var result = await _fruityViceService.GetAllFruitsCollection();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            [HttpGet("GetAllFruitsByFamily/{family}")]
            public async Task<ActionResult> GetAllFruitsByFamily(string family)
            {
                try
                {
                    var result = _fruityViceService.GetAllFruitsByFamily(family);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

}
