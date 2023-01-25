using eBusiness.DbContextFiles;
using eBusiness.Models;

namespace eBusiness.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }
        public List<Setting> GetSettings()
        {
            return _context.Settings.ToList();
        }
    }
}
