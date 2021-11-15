using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mastermind.DTOs;

namespace Mastermind.Entities
{
    public class AttemptResponseDTO: AttemptDTO
    {
        public int CorrectColors { get; set; }
        public int CorrectColorsAndPositions { get; set; }
        public int CurrentTry { get; set; }

        public static AttemptResponseDTO From(Attempt input)
        {
            return new AttemptResponseDTO()
            {
                CurrentTry = input.CurrentTry,
                GameId = input.GameId,
                ColorPattern = input.ColorPattern,
                CorrectColorsAndPositions = input.CorrectColorsAndPositions,
                CorrectColors = input.CorrectColors,
            };
        }
    }
}
