using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Directions.Results;
using HandyMapp.Data;
using HandyMapp.Models.Navigation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;

namespace HandyMapp.Controllers
{
    public class NavigationController : Controller
    {
        private List<Vector> _route;
        private Vector _start, _end;
        private List<Node> _openList, _closedList;
        private readonly ApplicationDbContext _context;

        public NavigationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowRoute(string from, string to)
        {
            var client = new MapsAPIClient("AIzaSyDfFiQB4uFA8_lS-24Ll1EFUXxfGVGoJWs");
            
            var directionsResult = client.Directions.GetDirections(from, to, TransportationModeEnum.Walking, null, true, null, "dutch", UnitSystemEnum.Metric, null, DateTime.Now, null, true, null, TransitRoutingPreferenceEnum.LessWalking, TrafficModelEnum.BestGuess);

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
        
        public IActionResult Navigate()
        {
            Calculate(_context.Vectors.First(x => x.Id == 27), _context.Vectors.First(x => x.Id == 1));
            return View();
        }

        public List<Vector> Calculate(Vector start, Vector end)
        {
            this._start = start;
            this._end = end;
            this._openList = new List<Node>();
            this._closedList = new List<Node>();
            Node current = new Node(null, start, 0, 0, start.GetDistance(end));
            _openList.Add(current);
            CalculateRoute();
            return _route;
        }

        private void CalculateRoute()
        {
            if (_openList.Count > 0)
            {
                _openList.Sort();
                Node current = _openList[0];

                if (current.Vector.Equals(_end))
                {
                    CreateRoute(current);
                    return;
                }
                _openList.Remove(current);
                _closedList.Add(current);
                DiscoverRoute(current);
                CalculateRoute();
            }
            _closedList.Clear();
        }

        private void DiscoverRoute(Node current)
        {
            Dictionary<VectorPath, Vector> vectorPaths = _context.VectorPaths.Where(x => x.VectorId1 == current.Vector.Id)
                .Join(_context.Vectors, vp => vp.VectorId2, v => v.Id, (vp, v) => new {VectorPath = vp, vector = v})
                .ToDictionary(x => x.VectorPath, x => x.vector);
            foreach (var at in vectorPaths)
            {
                double tCost = (double) at.Key.Distance;
                double gCost = current.GCost + tCost;
                double hCost = at.Value.GetDistance(_end);
                Node node = new Node(current, at.Value, tCost, gCost, hCost);
                if (!TerreinList(_openList, at.Value) && gCost >= node.GCost)
                {
                    if (!TerreinList(_openList, at.Value) || gCost < node.GCost)
                    {
                        _openList.Add(node);
                    }
                }
            }
        }

        private void CreateRoute(Node current)
        {
            _route = new List<Vector>();
            while (current.Parrent != null)
            {
                _route.Add(current.Vector);
                current = current.Parrent;
            }
            _route.Add(current.Vector);
            _route.Reverse();
            foreach (var var in _route)
            {
                Console.WriteLine(var.Id);
            }

            _openList.Clear();
            _closedList.Clear();
        }
        
        private bool TerreinList(List<Node> list, Vector vector)
        {
            return list.Any(n => n.Vector.Id == vector.Id);
        }
    }
}
