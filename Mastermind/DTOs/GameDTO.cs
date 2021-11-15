using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Mastermind.DTOs
{
    public class GameDTO
    {
        public string Name { get; set; }
        public int Tries { get; set; }
    }
}
