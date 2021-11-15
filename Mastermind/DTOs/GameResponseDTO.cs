using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mastermind.Entities;

namespace Mastermind.DTOs
{
    public class GameResponseDTO: GameDTO
    {
        public string Id { get; set; }

        public static GameResponseDTO From(Game input)
        {
            return new GameResponseDTO
            {
                Name = input.Name,
                Id = input.Id,
                Tries = input.Tries,
            };
        }
    }
}
