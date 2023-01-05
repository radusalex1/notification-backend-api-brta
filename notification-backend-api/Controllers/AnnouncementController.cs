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
            var result = await _announcementCollectionService.Get(id);
            return Ok(result);
        }
    }
}
