using System.Diagnostics;
using PetSpeak.Service.Reaction;
using PetSpeak.Service.Thread;
using PetSpeak.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace PetSpeak.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPetSpeakThreadService _PetSpeakThreadService;

        private readonly IReactionService _reactionService;

        public HomeController(IPetSpeakThreadService PetSpeakThreadService, IReactionService reactionService)
        {
            _PetSpeakThreadService = PetSpeakThreadService;
            _reactionService = reactionService;
        }

        public IActionResult Index()
        {
            this.ViewData["Threads"] = this._PetSpeakThreadService.GetAll().ToList();
            this.ViewData["Reactions"] = this._reactionService.GetAll().ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
