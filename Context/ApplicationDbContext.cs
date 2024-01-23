using EMS_Portal_Nomination.Data;
using Microsoft.EntityFrameworkCore;

namespace EMS_Portal_Nomination.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        { 
        
        }
        public DbSet<UserNominationForm> NominationFormByUser { get; set; }
    }
}
