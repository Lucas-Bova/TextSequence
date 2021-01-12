using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextSequence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SequenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SequenceController : ControllerBase
    {
        // POST api/<SequenceController>
        [HttpPost]
        public string Post([FromQuery] int floor, int ceiling, int limit, [FromBody] string data)
        {
            var jsonRsult = data.FindSequences(floor, ceiling, limit);
            return jsonRsult;
        }

    }
}
