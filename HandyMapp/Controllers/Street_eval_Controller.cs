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
        [HttpPost]
        public IActionResult street_eval(string walkingAid)
        {
            street_eval_model model = new street_eval_model();
            model.aid = walkingAid;
            HttpContext.Session.SetString("aid", JsonConvert.SerializeObject(walkingAid));

            List<street_eval_model> list = _context.StreetEvalModels.ToList();
            return View("street_eval",list);
        }
        street_eval_model model;
        [HttpPost]
        public IActionResult street_eval2(double Value1, double Value2)
        {
            model = new street_eval_model();
            model.lat = Value1;
            model.lng = Value2;

            HttpContext.Session.Set<Double>("lat", Value1);
            HttpContext.Session.Set<Double>("lng", Value2);
            return View("street_eval2", model);
        }
        
        public IActionResult street_eval3()
        {
            /*PlacesController placesC = new PlacesController(_context);
            model = new street_eval_model();
            string temp1 = HttpContext.Session.GetString("lat").ToString();
            string temp2 = HttpContext.Session.GetString("lng").ToString();
            double varlat = Convert.ToDouble(temp1);
            double varlng = Convert.ToDouble(temp2);
            List<PlaceDetails> bb = placesC.ByLatLng(varlat,varlng).ToList();
            string mystreet = bb[0].result.formatted_address;
            model.streetname = mystreet;
            HttpContext.Session.SetString("mystreet", JsonConvert.SerializeObject(mystreet));*/
            return View();
        }
        /*public IActionResult street_eval4()
        {
            return View();
        }*/
        street_eval_model model4;
        public IActionResult street_eval4(string myrating)
        {
            model4 = new street_eval_model();
            model4.rating = myrating;
            HttpContext.Session.SetString("rating", JsonConvert.SerializeObject(myrating));

            return View("street_eval4", model4);
        }
        public IActionResult street_eval5(string Obst_description, string selectedObst_type)
        {
            street_eval_model model4 = new street_eval_model();
            model4.aid = HttpContext.Session.GetString("aid");
            model4.lat = HttpContext.Session.Get<Double>("lat");
            model4.lng = HttpContext.Session.Get<Double>("lng");
            model4.rating = HttpContext.Session.GetString("rating");
            model4.description = Obst_description;
            model4.obst_type = selectedObst_type;
            if (model4 != null)
            {
                street_eval_model theModel = new street_eval_model()
                {
                    lat = model4.lat, lng = model4.lng, rating =model4.rating,description= model4.description,obst_type =  model4.obst_type
                };
                _context.StreetEvalModels.Add(theModel);
                _context.SaveChanges();
                HttpContext.Session.Clear();
                model4 = new street_eval_model();
            }      
            return View("street_eval5");
        }


        /*public IActionResult successfullEval(string Value1, string Value2, string rating, string Streetname, string Desc)
        {

            street_eval_model model = new street_eval_model();
            model.rating = rating;
            model.lat = Value1;
            model.lng = Value2;
            model.streetname = Streetname;
            model.description = Desc;

//street_eval_model theModel = new street_eval_model(model.lat, model.lng, model.streetname, model.description, model.rating);
           // _context.StreetEvals.Add(theModel);



            //_context.SaveChanges();
            //return View("street_eval2", theModel);
        }*/
    }
}
