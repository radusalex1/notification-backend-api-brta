namespace notification_backend_api.Models
{

    public class Announcement
    {
        public Guid Id { get; set; }
        public string  Title { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public string AuthorId { get; set; }
    }
}
