using GigHub.Models;
using GigHub.ViewModels;
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

        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _dbContext.Genres.ToList()
            };

            return View(viewModel);
        }
    }
}