using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Entities
{
    public class Attempt
    {
        public string[] ColorPattern { get; set; }
        public string GameId { get; set; }
        public int CorrectColors { get; set; }
        public int CorrectColorsAndPositions { get; set; }
        public int CurrentTry { get; set; }
    }
}
