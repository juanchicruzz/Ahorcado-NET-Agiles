using Hangman.Models;
using Hangman.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hangman.Controllers
{
    public class PlayerController : Controller
    {
        private readonly HangmanService _hangmanService;
        public PlayerController(HangmanService hangmanService)
        {
            _hangmanService = hangmanService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext != null && SessionHelper.GetObjectFromJson<HangmanModel>(HttpContext.Session, "game") != null)
            {
                HttpContext.Session.Remove("game");
            }
            return View(new PlayerModel());
        }

        [HttpPost]
        public IActionResult Index(PlayerModel player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            HangmanModel hangman = _hangmanService.SetPlayers(player.Player1, player.Player2);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "game", hangman);
            return RedirectToAction("StartGame", "Hangman");
        }
    }
}
