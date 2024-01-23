using EMS_Portal_Nomination.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS_Portal_Nomination.Services
{
    public class DBService
    {
        private readonly DataContext db;

        public DBService(DataContext _db)
        {
            db = _db;
        }

        public async Task AddNewNomination(UserNomination nomination)
        {
            await db.AddAsync(nomination);
            await db.SaveChangesAsync();
        }

        public async Task<List<UserNomination>> GetNominations()
        {
            return await db.UserNomination.ToListAsync();
        }
    }
}
