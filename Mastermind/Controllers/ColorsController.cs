using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mastermind.DTOs;

namespace Mastermind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly ColorsService colorsService;

        public ColorsController(ColorsService colorsService)
        {
            this.colorsService = colorsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(colorsService.GetAll());
        }
    }
}
