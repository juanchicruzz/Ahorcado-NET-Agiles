using Hangman.Models;
using Hangman.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hangman.Controllers
{
    public class HangmanController : Controller
    {
        private readonly HangmanService _hangmanService;

        public HangmanController(HangmanService hangmanService)
        {
            _hangmanService = hangmanService;
        }

        [HttpGet]
        public IActionResult StartGame()
        {
            HangmanModel hangman = SessionHelper.GetObjectFromJson<HangmanModel>(HttpContext.Session, "game");

            hangman = _hangmanService.StartGame(hangman);

            SessionHelper.SetObjectAsJson(HttpContext.Session, "game", hangman);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Index()
        {
            HangmanModel hangman = SessionHelper.GetObjectFromJson<HangmanModel>(HttpContext.Session, "game");
            return View(hangman);
        }

        [HttpPost]
        public IActionResult Index(HangmanModel hangman)
        {
            if (!ModelState.IsValid)
            {
                return View(SessionHelper.GetObjectFromJson<HangmanModel>(HttpContext.Session, "game"));
            }

            hangman = _hangmanService.SetWordToGuess(
                hangman.WordToGuess,
                SessionHelper.GetObjectFromJson<HangmanModel>(HttpContext.Session, "game"));

            SessionHelper.SetObjectAsJson(HttpContext.Session, "game", hangman);
            return RedirectToAction("Play");
        }

        [HttpGet]
        public IActionResult Play()
        {
            HangmanModel hangman = SessionHelper.GetObjectFromJson<HangmanModel>(HttpContext.Session, "game");
            return View(hangman);
        }

        [HttpPost]
        public IActionResult Play(HangmanModel hangman)
        {
            if (!ModelState.IsValid || hangman.Attempt == null)
            {
                ModelState.AddModelError("Attempt", "El campo es requerido");
                return View(SessionHelper.GetObjectFromJson<HangmanModel>(HttpContext.Session, "game"));
            }

            hangman = _hangmanService.Try(
                hangman.Attempt,
                SessionHelper.GetObjectFromJson<HangmanModel>(HttpContext.Session, "game"));

            SessionHelper.SetObjectAsJson(HttpContext.Session, "game", hangman);
            return RedirectToAction("Play");
        }

    }
}
