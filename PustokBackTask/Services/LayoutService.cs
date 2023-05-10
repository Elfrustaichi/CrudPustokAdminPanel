using PustokBackTask.DAL;
using PustokBackTask.Models;

namespace PustokBackTask.Services
{
    public class LayoutService
    {
        private readonly DataContext _context;

        public LayoutService(DataContext context)
        {
            _context = context;
        }
        public Dictionary<string,string> GetSettings()
        {
            return _context.Settings.ToDictionary(x=>x.Key,x=>x.Value);
        }

        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}
