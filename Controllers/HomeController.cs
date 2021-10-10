using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            // 1. all womens' leagues
            ViewBag.ProblemOne = _context.Leagues
                .Where(leauge => leauge.Name.Contains("Women"))
                .ToList();

            // 2. all leagues where sport is any type of hockey
            ViewBag.ProblemTwo = _context.Leagues
                .Where(leauge => leauge.Sport.Contains("Hockey"))
                .ToList();

            //3. all leagues where sport is something OTHER THAN football
            ViewBag.ProblemThree = _context.Leagues
                .Where(leauge => !leauge.Sport.Contains("Football"))
                .ToList();

            // 4. all leagues that call themselves "conferences"
            ViewBag.ProblemFour = _context.Leagues
                .Where(leauge => leauge.Name.Contains("Conference"))
                .ToList();

            //5. all leagues in the Atlantic region
            ViewBag.ProblemFive = _context.Leagues
                .Where(leauge => leauge.Name.Contains("Atlantic"))
                .ToList();

            // 6. all teams based in Dallas
            ViewBag.ProblemSix = _context.Teams
                .Where(team => team.Location.Contains("Dallas"))
                .ToList();

            // 7. all teams named the Raptors
            ViewBag.ProblemSeven = _context.Teams
                .Where(team => team.TeamName.Contains("Raptors"))
                .ToList();

            // 8. all teams whose location includes "City"
            ViewBag.ProblemEight = _context.Teams
                .Where(team => team.Location.Contains("City"))
                .ToList();

            // 9. all teams whose names begin with "T"
            ViewBag.ProblemNine = _context.Teams
                .Where(team => team.TeamName.Contains("T"))
                .ToList();

            // 10. all teams, ordered alphabetically by location
            ViewBag.ProblemTen = _context.Teams
                .OrderBy(team => team.TeamName)
                .ToList();

            //11. all teams, ordered by team name in reverse alphabetical order
            ViewBag.ProblemEleven = _context.Teams
                .OrderByDescending(team => team.TeamName)
                .ToList();

            // 12. every player with last name "Cooper
            ViewBag.ProblemTwelve = _context.Players
            .Where(player => player.LastName.Contains("Cooper"))
            .ToList();

            // 13. every player with first name "Joshua"
            ViewBag.ProblemThirteen = _context.Players
            .Where(player => player.FirstName.Contains("Joshua"))
            .ToList();

            // 14. every player with last name "Cooper" EXCEPT those with "Joshua" as the first name
            ViewBag.ProblemFourteen = _context.Players
            .Where(player => player.LastName.Contains("Cooper") && !player.FirstName.Contains("Joshua"))
            .ToList();

            //15. all players with first name "Alexander" OR first name "Wyatt"
            ViewBag.ProblemFifteen = _context.Players
            .Where(player => player.FirstName.Contains("Alexander") || player.FirstName.Contains("Wyatt"))
            .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}