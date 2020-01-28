using Microsoft.EntityFrameworkCore;

namespace HFT.Models
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
        }

        public DbSet<EventItem> Events { get; set; }
    }
}
