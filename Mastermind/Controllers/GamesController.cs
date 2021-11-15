using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mastermind.DTOs;
using Mastermind.Entities;
using Mastermind.Services;

namespace Mastermind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesService gamesService;

        public GamesController(GamesService gamesService)
        {
            this.gamesService = gamesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(gamesService.GetAll());
        }

        [HttpGet("{gameId}")]
        public IActionResult Get(string gameId)
        {
            var game = gamesService.GetGameById(gameId);
            if (game == null)
            {
                return BadRequest("Invalid game id");
            }
            return Ok(game);
        }

        [HttpPost("new")]
        public IActionResult NewGame([FromBody] GameDTO input)
        {
            return Ok(GameResponseDTO.From(gamesService.CreateNewGame(input)));
        }

        [HttpGet("attempts/{gameId}")]
        public IActionResult GetAttempts(string gameId)
        {
            var attempts = gamesService.GetGameAttempts(gameId);
            if (attempts == null)
            {
                return BadRequest("Invalid Game ID");
            }
            Console.WriteLine(attempts.Count);
            return Ok(attempts);
        }

        [HttpPost("attempt")]
        public IActionResult Attempt([FromBody] AttemptDTO input)
        {
            return Ok(AttemptResponseDTO.From(gamesService.Attempt(input)));
        }
    }
}
