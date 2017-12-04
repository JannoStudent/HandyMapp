using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Directions.Results;
using HandyMapp.Data;
using HandyMapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HandyMapp.Models.Navigation;

namespace HandyMapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Preferences()
        {
            return View();
        }

        public IActionResult SelectWalkingAid()
        {
            return View();
        }

        public IActionResult InputRoute()
        {
            return View();
        }

        public IActionResult RouteOptions()
        {
            return View();
        }

        public IActionResult RouteOnMap()
        {
            return View();
        }

        public IActionResult WayOfSearching()
        {
            return View("~/Views/Home/Buildings/WayOfSearching.cshtml");
        }

        public IActionResult PlaceInput()
        {
            return View("~/Views/Home/Buildings/PlaceInput.cshtml");
        }

        public IActionResult SelectArea()
        {
            return View("~/Views/Home/Buildings/SelectArea.cshtml");
        }

        public IActionResult PlacesResult()
        {
            return View("~/Views/Home/Buildings/PlacesResult.cshtml");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult TestAPI()
        {
            // Get client
            var client = new MapsAPIClient("AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs");

            var startString = "Amerikaweg 201, 2717 AZ Zoetermeer, Netherlands";
            var endString = "Aziëweg, 2726 Zoetermeer, Netherlands";
            var directionsResult = client.Directions.GetDirections(startString, endString, TransportationModeEnum.Walking, null, true, null, "dutch", UnitSystemEnum.Metric, null, DateTime.Now, null, true, null, TransitRoutingPreferenceEnum.LessWalking, TrafficModelEnum.BestGuess);

            List<GetDirectionsRouteResult> routes = directionsResult.Routes;
            //List<Vector> vectors = new List<Vector>();
            //VectorNeighbor neighbor = null;

            foreach (var route in directionsResult.Routes)
            {
                foreach (var leg in route.Legs)
                {
                    foreach (var step in leg.Steps)
                    {
                        Vector parent = new Vector(step.StartLocation.Latitude, step.StartLocation.Longitude);
                        Vector child = new Vector(step.EndLocation.Latitude, step.EndLocation.Longitude);
                        VectorPath vectorPath1 = new VectorPath(step.Distance.Value)
                        {
                            VectorId1Navigation = parent,
                            VectorId2Navigation = child
                        };
                        VectorPath vectorPath2 = new VectorPath(step.Distance.Value)
                        {
                            VectorId1Navigation = child,
                            VectorId2Navigation = parent
                        };

                        if (!_context.Vectors.Any(x => x.Latitude == step.StartLocation.Latitude && x.Longitude == step.StartLocation.Longitude))
                        {
                            _context.Vectors.Add(parent);
                            _context.VectorPaths.Add(vectorPath1);
                            _context.SaveChanges();
                        }

                        if (!_context.Vectors.Any(x =>
                            x.Latitude == step.EndLocation.Latitude && x.Longitude == step.EndLocation.Longitude))
                        {
                            _context.Vectors.Add(child);
                            _context.VectorPaths.Add(vectorPath2);
                            _context.SaveChanges();
                        }

                        parent = _context.Vectors.First(x =>
                            x.Latitude == step.StartLocation.Latitude &&
                            x.Longitude == step.StartLocation.Longitude);
                        child = _context.Vectors.First(x =>
                            x.Latitude == step.EndLocation.Latitude &&
                            x.Longitude == step.EndLocation.Longitude);
                        
                        if (!_context.VectorPaths.Any(x => x.VectorId1 == parent.Id && x.VectorId2 == child.Id))
                        {
                            vectorPath1 = new VectorPath(step.Distance.Value)
                            {
                                VectorId1Navigation = parent,
                                VectorId2Navigation = child
                            };
                            _context.VectorPaths.Add(vectorPath1);
                        }
                        if (!_context.VectorPaths.Any(x => x.VectorId1 == child.Id && x.VectorId2 == parent.Id))
                        {
                            vectorPath2 = new VectorPath(step.Distance.Value)
                            {
                                VectorId1Navigation = child,
                                VectorId2Navigation = parent
                            };
                            _context.VectorPaths.Add(vectorPath2);
                        }
                    }
                }
            }
            _context.SaveChanges();

            return View(directionsResult);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}
