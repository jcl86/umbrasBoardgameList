using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameParser.Models;
using GameParser.Core;
using System.IO;
using Newtonsoft.Json;

namespace GameParser.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<BoardGame> games = GetBoardGames();
            var viewModel = new GameViewModel
            {
                Boardgames = games.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(GameViewModel viewModel)
        {
            IEnumerable<BoardGame> boardGames = GetBoardGames();

            var games = boardGames.ToList();

            if (viewModel.PlayerNumber.HasValue)
                games = games.Where(x => viewModel.PlayerNumber.Value >= x.PlayerMin && viewModel.PlayerNumber.Value <= x.PlayerMax).ToList();

            if (viewModel.Level.HasValue)
                games = games.Where(x => x.Dificulty.HasValue && viewModel.Level == x.Dificulty).ToList();

            if (viewModel.Minutos.HasValue)
                games = games.Where(x => viewModel.Minutos.Value >= x.Duration).ToList();

            if (viewModel.Edad.HasValue)
                games = games.Where(x => x.Years <= viewModel.Edad.Value).ToList();

            viewModel.Boardgames = games;

            return View(viewModel);
        }

        public IActionResult Local()
        {
            IEnumerable<BoardGame> games = GetLocalGames();
            var viewModel = new GameViewModel
            {
                Boardgames = games.ToList()
            };

            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult Local(GameViewModel viewModel)
        {
            IEnumerable<BoardGame> boardGames = GetLocalGames();

            var games = boardGames.ToList();

            if (viewModel.PlayerNumber.HasValue)
                games = games.Where(x => viewModel.PlayerNumber.Value >= x.PlayerMin && viewModel.PlayerNumber.Value <= x.PlayerMax).ToList();

            if (viewModel.Level.HasValue)
                games = games.Where(x => x.Dificulty.HasValue && viewModel.Level == x.Dificulty).ToList();

            if (viewModel.Minutos.HasValue)
                games = games.Where(x => viewModel.Minutos.Value >= x.Duration).ToList();

            if (viewModel.Edad.HasValue)
                games = games.Where(x => x.Years <= viewModel.Edad.Value).ToList();

            viewModel.Boardgames = games;

            return View("Index", viewModel);
        }


        private static IEnumerable<BoardGame> GetBoardGames()
        {
#if DEBUG
            string path = $"{Directory.GetCurrentDirectory()}\\games.json";
            var json = new Reader(path).Read();
#else
            var uri = Api.GamesUrl;
            var json = new UrlReader(uri).Read();
#endif

            RootObject result;
            try
            {
                result = JsonConvert.DeserializeObject<RootObject>(json);
            }
            catch (Exception)
            {
                try
                {
                    json = json.Substring(0, json.LastIndexOf('}')) + "}],\"MensajeError\": \"\"}";
                    result = JsonConvert.DeserializeObject<RootObject>(json);
                }
                catch (Exception)
                {
                    string localPath = $"{Directory.GetCurrentDirectory()}\\games.json";
                    json = new Reader(localPath).Read();
                    result = JsonConvert.DeserializeObject<RootObject>(json);
                }
            }
            
            var boardGames = result.Convert();
            return boardGames;
        }

        private static IEnumerable<BoardGame> GetLocalGames()
        {
            string path = $"{Directory.GetCurrentDirectory()}\\games.json";
            var json = new Reader(path).Read();

            RootObject result;
            result = JsonConvert.DeserializeObject<RootObject>(json);
            var boardGames = result.Convert();
            return boardGames;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
