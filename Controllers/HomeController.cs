using BowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context;

        //bring in database
        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext con)
        {
            context = con;
            _logger = logger;
        }

        public IActionResult Index(long? teamid, int pageNum = 0)
        {
            //.Where(x => x.RecipeTitle.Contains("Nachos"))
            //.FromSqlInterpolated($"SELECT * FROM Recipes WHERE RecipeTitle LIKE {variable}")

            int pageSize = 5;

            return View(context.Bowlers
                .Where(x => x.TeamId == teamid || teamid == null)
                .OrderBy(x => x.BowlerLastName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList());

                //.FromSqlInterpolated($"Select * FROM Bowlers WHERE TeamID = {teamid} OR {teamid} IS NULL")
                //.ToList());
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
