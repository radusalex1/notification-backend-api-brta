using notification_backend_api.Models;

namespace notification_backend_api.Servicies
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {

        static List<Announcement> _announcements = new List<Announcement> { new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "First Announcement", Description = "First Announcement Description" , AuthorId = "Author_1"},
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Second Announcement", Description = "Second Announcement Description", AuthorId = "Author_1" },
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Third Announcement", Description = "Third Announcement Description", AuthorId = "Author_2"  },
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fourth Announcement", Description = "Fourth Announcement Description", AuthorId = "Author_3"  },
        new Announcement { Id = Guid.NewGuid(), CategoryId = "1", Title = "Fifth Announcement", Description = "Fifth Announcement Description", AuthorId = "Author_4"  }
        };

        public bool Create(Announcement model)
        {
            if(model==null)
            {
                return false;
            }

            _announcements.Add(model);


            return true;
        }

        public bool Delete(Guid id)
        {
            if(id==null)
            {
                return false;
            }

            _announcements.Remove(_announcements.FirstOrDefault(a => a.Id == id));

            return true;
            
        }

        public Announcement Get(Guid id)
        {
            return _announcements.FirstOrDefault(a => a.Id == id);
        }

        public List<Announcement> GetAll()
        {
            return _announcements;
        }

        public List<Announcement> GetAnnouncementsByCategoryId(string categoryId)
        {
            return _announcements.Where(a => a.CategoryId == categoryId).ToList();
        }

        public bool Update(Guid id, Announcement model)
        {
            if (id == null)
            {
                return false;
            }

            var a = _announcements.FirstOrDefault(a => a.Id == id);

            if (a == null)
            {
                return false;
            }

            a.Id = id;

            a=model;

            _announcements[_announcements.IndexOf(a)] = a;

            return true;
        }
    }
}
