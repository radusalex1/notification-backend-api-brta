using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using notification_backend_api.Models;
using notification_backend_api.Servicies;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace notification_backend_api.Controllers
{
    [Route("Announcement")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            List<Announcement> announcements = await _announcementCollectionService.GetAll();
            return Ok(announcements);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] Announcement announcement)
        {
            var result = await _announcementCollectionService.Create(announcement);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncement(Guid id)
        {
            var result = await _announcementCollectionService.GetByID(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOne(Guid id)
        {
            await _announcementCollectionService.Delete(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> deleteAll()
        {
            var result = await _announcementCollectionService.deleteAll();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] Announcement announcement)
        {
            if (id == null)
            {
                return BadRequest("id not found");
            }

            var result = await _announcementCollectionService.Update(id, announcement);

            return Ok(result);
        }
    }
}
