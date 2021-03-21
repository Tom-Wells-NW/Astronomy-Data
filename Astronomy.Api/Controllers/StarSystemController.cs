using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Threading.Tasks;
using Astronomy.Core.Interfaces;
using Astronomy.Core.Models;
using Astronomy.Data.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Astronomy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StarSystemsController : ControllerBase
    {

        private readonly ILogger<StarSystemsController> _logger;
        private readonly IStarSystemDataService _starSystemDataService;

        public StarSystemsController(IStarSystemDataService starSystemDataService,ILogger<StarSystemsController> logger)
        {
            _starSystemDataService = starSystemDataService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IStarSystem>> Get(int id)
        {
            if (id < 0)
                return BadRequest();

            var result = await _starSystemDataService.GetStarSystemAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IStarSystemList>> Get(double Xmin, double Ymin, double Zmin, double Xmax, double Ymax, double Zmax)
        {
            if (isBadRange(Xmin, Ymin, Zmin, Xmax, Ymax, Zmax))
                return BadRequest();

            var result = await _starSystemDataService.GetStarsInCoordinateRangeAsync(Xmin, Ymin, Zmin, Xmax, Ymax, Zmax);
            return Ok(result);
        }

        private bool isBadRange(double Xmin, double Ymin, double Zmin, double Xmax, double Ymax, double Zmax)
        {
            var result = false;

            if (Xmin >= Xmax) result = true;
            if (Ymin >= Ymax) result = true;
            if (Zmin >= Zmax) result = true;

            return result;
        }
    }
}
