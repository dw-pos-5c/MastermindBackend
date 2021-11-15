using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.DTOs
{
    public class ColorsService
    {
        private readonly List<string> games = new List<string>()
        {
            "Yellow",
            "Orange",
            "Green",
            "Red",
            "Blue",
            "Purple",
        };

        public List<string> GetAll()
        {
            return games;
        }
    }
}
