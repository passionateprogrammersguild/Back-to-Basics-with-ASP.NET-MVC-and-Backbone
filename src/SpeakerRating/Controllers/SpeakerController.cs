using System;
using System.Web.Mvc;

namespace SpeakerRating.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly SpeakerService _speakerService;
        public SpeakerController(SpeakerService speakerService)
        {
            _speakerService = speakerService;
        }
        public ActionResult Speaker(int id)
        {
            return View(_speakerService.Find(id));
        }

        public ActionResult Speakers()
        {
            return View(_speakerService.FindAll());
        }

        public bool ShowingAllSpeakers()
        {
            return this.RouteData.Values["id"] == null;
        }
    }
}