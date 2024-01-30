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

        public async Task<bool> ValidateLogin(Sign loginData)
        {
            // Check if the username and password match in the database
            bool isValid = await db.Sign.AnyAsync(u => u.UserName == loginData.UserName && u.Password == loginData.Password);

            return isValid;
        }

        public async Task AddSign(Sign Sign)
        {
            await db.AddAsync(Sign);
            await db.SaveChangesAsync();
        }

        public async Task AddNewRole(Role Role)
        {
            await db.AddAsync(Role);
            await db.SaveChangesAsync();
        }
        public async Task UpdateNewNomination(UserNomination nomination)
        {
            var existingNomination = await db.UserNomination.FindAsync(nomination.Id); // Assuming there's an 'Id' property in your UserNomination class
            if (existingNomination != null)
            {
                db.Entry(existingNomination).CurrentValues.SetValues(nomination);
                await db.SaveChangesAsync();
            }
        }

        public async Task<List<UserNomination>> GetNominations()
        {

            return await db.UserNomination.ToListAsync();
        }

        public async Task<List<UserNomination>> GetNominationsByEmailId(string email)
        {

            return await db.UserNomination.Where(x => x.EmailId == email).ToListAsync();
        }

    }
}
