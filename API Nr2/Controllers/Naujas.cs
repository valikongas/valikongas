using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Nr2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Naujas : ControllerBase
    {
    public class TekstoModelis
    {
        public string Text { get; set; }
    }
        [HttpPost("XXX")]
        public ActionResult<string> BackText([FromBody] TekstoModelis modelis)
        {
            string atsakymas = modelis.Text + " ASDFGHT ZXCVBNM";
            return Ok(new { message = atsakymas });
//            return Ok(atsakymas);
        }

    }
}

