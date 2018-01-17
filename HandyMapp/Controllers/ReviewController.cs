using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandyMapp.Models;
using HandyMapp.Models.Navigation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandyMapp.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public IActionResult Index()
        {
            return Redirect("SelectWalkingAid");
        }

        public IActionResult SelectWalkingAid()
        {
            return View();
        }

        public IActionResult SelectReview(string walkingAid)
        {
            if (string.IsNullOrEmpty(walkingAid))
            {
                if (HttpContext.Session.Get<MobilityType>("MobilityType") == MobilityType.Undefined)
                {
                    return View("SelectWalkingAid");
                }
                else
                {
                    return View();
                }
            }
            HttpContext.Session.Set<MobilityType>("MobilityType", (MobilityType)Enum.Parse(typeof(MobilityType), walkingAid));
            return View();
        }
    }
}