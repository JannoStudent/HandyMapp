using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyMapp.Controllers.API;
using HandyMapp.Data;
using HandyMapp.Models.GoogeApi;
using Microsoft.AspNetCore.Mvc;

namespace HandyMapp.Controllers
{
    public class ReviewPlacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewPlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchPlaces(string searchstext)
        {
            PlacesController placesController = new PlacesController(_context);
            return PartialView("~/Views/PartialView/CardListPlaceDetails.cshtml",placesController.AutoComplete(searchstext).Result.Select(x => placesController.Get(x.PlaceId)).ToList());
        }
    }
}