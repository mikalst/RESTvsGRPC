using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.Data;
using ModelLibrary.REST;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeteoriteLandingsController : ControllerBase
    {
        [HttpGet("Payload/{size}")]
        public IEnumerable<MeteoriteLanding> GetLargePayloadAsync([FromRoute] int size)
        {
            MeteoriteLandingData.Size = (MeteoriteLandingDataSize)size;
            return MeteoriteLandingData.RestMeteoriteLandings;
        }

        // POST api/values/LargePayload
        [HttpPost]
        [Route("Payload")]
        public string PostPayload([FromBody] IEnumerable<MeteoriteLanding> meteoriteLandings)
        {
            return "SUCCESS";
        }
    }
}
