using Microsoft.AspNetCore.Mvc;
using notification_backend_api.Models;
using notification_backend_api.Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace notification_backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }


        // GET: api/<AnnouncementController>
        [HttpGet]
        [Route("/GetAllAnnouncements")]
        public IActionResult GetAnnouncements()
        {
            List<Announcement> Announcements = _announcementCollectionService.GetAll();
            return Ok(Announcements);
        }


        // POST api/<AnnouncementController>
        //[HttpPost]
        //public IActionResult CreateAnnouncement([FromBody] Announcement announcement)
        //{
        //    if (announcement == null)
        //    {
        //        return BadRequest("Announcement cannot be null");
        //    }

        //    _announcements.Add(announcement);

        //    return Ok(announcement);
        //}


        //// PUT api/<AnnouncementController>/5
        //[HttpPut("{id}")]
        //public IActionResult UpdateAnnouncement(Guid id,[FromBody] Announcement announcement)
        //{
        //    if (announcement == null)
        //    {
        //        return BadRequest("Announcement cannot be null");
        //    }

        //    if(!_announcements.Any(a=>a.Id==announcement.Id))
        //    {
        //        return NotFound("Announcement cannot be found");
        //    }

        //    announcement.Id = id;

        //    _announcements[_announcements.IndexOf(announcement)] = announcement;

        //    return Ok(announcement);
        //}

        //// DELETE api/<AnnouncementController>/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id,[FromBody] Announcement announcement)
        //{
        //    if (announcement == null)
        //    {
        //        return BadRequest("Announcement cannot be null");
        //    }

        //    if (!_announcements.Any(a => a.Id == announcement.Id))
        //    {
        //        return NotFound("Announcement cannot be found");
        //    }

        //    _announcements.Remove(announcement);
        //    return Ok("Announcement removed");

        //}
    }
}
