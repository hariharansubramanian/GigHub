using System.Linq;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int gigId)
        {

            var userId = User.Identity.GetUserId();

            if (_dbContext.Attendances.Any(a=> a.AttendeeId == userId && a.GigId == gigId))
            {
                return BadRequest("The attendance already exists.");
            }
            
            var attendance = new Attendance()
            {
                GigId = gigId,
                AttendeeId = userId
            };
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}