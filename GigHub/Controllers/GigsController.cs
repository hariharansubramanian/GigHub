using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public GigsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var artistId = User.Identity.GetUserId();
            var artist = _dbContext.Users.Single(u => u.Id == artistId);
            var genre = _dbContext.Genres.Single(g => g.Id == viewModel.Genre);
            var gig = new Gig
            {
                Artist = artist,
                DateTime = DateTime.Parse($"{viewModel.Date} {viewModel.Time}"),
                Genre = genre,
                Venue = viewModel.Venue
            };
            _dbContext.Gigs.Add(gig);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}