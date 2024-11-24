using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YMYPHibrit3Group.API.Filters;

namespace YMYPHibrit3Group.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterExampleController : ControllerBase
    {
        [MyExceptionFilter]
        [HttpGet]
        public IActionResult Get(string id)
        {
            throw new Exception("Db hatası");
            //try
            //{
            //    var x = int.Parse(id);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //   return BadRequest("")
            //}


            return Ok("Get request");
        }


        [HttpPost]
        public IActionResult Post()
        {
            throw new Exception("Db hatası");


            return Ok("Post request");
        }


        [MyResultFilter]
        [HttpPut]
        public IActionResult Put()
        {
            return Ok("PUT request");
        }
    }
}