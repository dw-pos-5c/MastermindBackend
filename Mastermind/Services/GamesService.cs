using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mastermind.DTOs;
using Mastermind.Entities;

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Mastermind.Services
{
    public class GamesService
    {
        private readonly ColorsService colorsService;
        private readonly List<Game> games = new List<Game>();
        private readonly List<Attempt> attempts = new List<Attempt>();

        public GamesService(ColorsService colorsService)
        {
            this.colorsService = colorsService;
        }

        private readonly char[] chars = { 
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'D', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
        };

        public List<Game> GetAll()
        {
            return games;
        }

        public Game CreateNewGame(GameDTO input)
        {
            var game = new Game
            {
                Name = input.Name,
                Tries = input.Tries,
                CurrentTry = 1,
                Id = GenerateRandomId(6),
                ColorPattern = GenerateRandomColorPalette(),
            };
            games.Add(game);

            foreach (string colors in game.ColorPattern)
            {
                Console.WriteLine(colors);
            }

            return game;
        }

        private string GenerateRandomId(int length)
        {
            string id;
            do
            {
                id = "";
                for (var i = 0; i < length; i++)
                {
                    id += chars[new Random().Next(0, chars.Length - 1)];
                }
                Console.WriteLine(id);
            } while (games.Any(x => x.Id.Equals(id)));

            return id;
        }

        private string[] GenerateRandomColorPalette()
        {
            var availColors = colorsService.GetAll();
            var palette = new List<string>();
            for (var i = 0; i < 4; i++)
            {
                palette.Add(availColors[new Random().Next(0, availColors.Count - 1)]);
            }

            return palette.ToArray();
        }

        public Attempt Attempt(AttemptDTO input)
        {
            var attempt = new Attempt()
            {
                GameId = input.GameId,
                ColorPattern = input.ColorPattern,
                CurrentTry = GetCurrentTry(input.GameId),
                CorrectColors = CalcCorrectColors(input.GameId, input.ColorPattern),
                CorrectColorsAndPositions = CalcCorrectColorsAndPositions(input.GameId, input.ColorPattern),
            };

            attempts.Add(attempt);

            return attempt;
        }

        public Game GetGameById(string gameId)
        {
            return games.FirstOrDefault(x => x.Id.Equals(gameId));
        }

        private int CalcCorrectColors(string gameId, string[] colorPattern)
        {
            var correct = 0;
            var game = GetGameById(gameId);
            if (game == null) return -1;

            var gamePattern = game.ColorPattern.ToList();

            foreach (string color in colorPattern)
            {
                if (gamePattern.Contains(color)) correct++;
                gamePattern.Remove(color);
            }

            return correct;
        }

        private int CalcCorrectColorsAndPositions(string gameId, string[] colorPattern)
        {
            var correct = 0;
            var game = GetGameById(gameId);
            if (game == null) return -1;

            for (var i = 0; i < colorPattern.Length; i++)
            {
                if (colorPattern[i].Equals(game.ColorPattern[i])) correct++;
            }

            return correct;
        }

        private int GetCurrentTry(string gameId)
        {
            var game = GetGameById(gameId);
            if (game == null) return -1;
            var currTry = game.CurrentTry;
            game.CurrentTry++;
            return currTry;
        }

        public List<Attempt> GetGameAttempts(string gameId)
        {
            var game = GetGameById(gameId);
            if (game == null) return null;
            Console.WriteLine(gameId);
            return attempts.Where(x => x.GameId.Equals(gameId)).ToList();
        }
    }
}
