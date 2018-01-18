using HandyMapp.Data;
using HandyMapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using HandyMapp.Controllers.API;
using HandyMapp.Models.GoogeApi;
using System.Linq;
using System.Globalization;
using HandyMapp.Models.Navigation;

namespace HandyMapp.Controllers
{
    public class Street_eval_Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string LogOnSession = "rating";  //session rating name

        public Street_eval_Controller(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult select_walking_aid()
        {
            return View();
        }
        public IActionResult street_eval()
        {
            List<street_eval_model> list = _context.StreetEvalModels.ToList();
            return View("street_eval", list);
        }
       
        street_eval_model model;
        public IActionResult street_eval2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult street_eval2(string lat, string lng, string streetname)
        {
            model = new street_eval_model();
            if (string.IsNullOrEmpty(lat) && string.IsNullOrEmpty(lng) && string.IsNullOrEmpty(streetname))
            {
                lat = HttpContext.Session.GetString("lat");
                lng = HttpContext.Session.GetString("lng");
                streetname = HttpContext.Session.GetString("streetname");
            }
            else
            {
                model.lat = lat;
                model.lng = lng;
                model.streetname = streetname;
                HttpContext.Session.SetString("lat", lat);
                HttpContext.Session.SetString("lng", lng);
                HttpContext.Session.SetString("streetname", streetname);
            }
            return View("street_eval2", model);
        }

        public IActionResult street_eval3()
        {

            return View();
        }
        [HttpGet]
        public IActionResult street_eval3(street_eval_model model)
        {

            return View("street_eval3", model);
        }

        [HttpPost]
        public IActionResult street_eval4(string myrating)
        {
            model = new street_eval_model();
            model.rating = myrating;
            HttpContext.Session.SetString("rating", JsonConvert.SerializeObject(myrating));
            return View("street_eval4", model);
        }
        public IActionResult street_eval5(string Obst_description, string selectedObst_type)
        {
            street_eval_model model = new street_eval_model();
            model.aid = HttpContext.Session.Get<MobilityType>("MobilityType");
            model.lat = HttpContext.Session.Get<String>("lat");
            model.lng = HttpContext.Session.Get<String>("lng");
            model.streetname = HttpContext.Session.GetString("streetname");
            model.rating = HttpContext.Session.GetString("rating");
            model.description = Obst_description;
            model.obst_type = selectedObst_type;
            if (model != null)
            {
                street_eval_model theModel = new street_eval_model()
                {
                    aid = model.aid,
                    lat = model.lat,
                    lng = model.lng,
                    streetname = model.streetname,
                    rating = model.rating,
                    description = model.description,
                    obst_type = model.obst_type
                };
                _context.StreetEvalModels.Add(theModel);
                _context.SaveChanges();
                HttpContext.Session.Clear();
                model = new street_eval_model();
            }
            return View("street_eval5");
        }
    }
}
