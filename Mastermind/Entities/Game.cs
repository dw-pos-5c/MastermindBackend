using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

using Mastermind.DTOs;

namespace Mastermind.Entities
{
    public class Game
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Tries { get; set; }
        public int CurrentTry { get; set; }
        public string[] ColorPattern { get; set; }
        
    }
}
