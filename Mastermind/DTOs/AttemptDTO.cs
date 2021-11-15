using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Mastermind.DTOs
{
    public class AttemptDTO
    {
        public string[] ColorPattern { get; set; }
        public string GameId { get; set; }
    }
}
