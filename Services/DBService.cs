using EMS_Portal_Nomination.Data;
using EMS_Portal_Nomination.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace EMS_Portal_Nomination.Services
{
    public class DBService
    {
        private readonly IdentityContext db;

        public DBService(IdentityContext _db)
        {
            db = _db;
        }

        public async Task AddNewNomination(UserNomination nomination)
        {
            await db.AddAsync(nomination);
            await db.SaveChangesAsync();
        }

        public async Task AddNewRole(Role role)
        {
            await db.AddAsync(role);
            await db.SaveChangesAsync();
        }

        public async Task UpdateNewNomination(UserNomination nomination)
        {
            var existingNomination = await db.UserNomination.FindAsync(nomination.Id);
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

        public async Task<List<RoleMapping>> GetCurrentRoleAndEmail(string currentUserEmail)
        {
            // Assuming db is your DbContext instance
            return await db.RoleMapping
                .Where(r => r.UserID == currentUserEmail)
                .ToListAsync();
        }


        public async Task<List<UserNomination>> GetNominationsByEmailId(string email)
        {
            return await db.UserNomination.Where(x => x.EmailId == email).ToListAsync();
        }

        public async Task<List<Role>> GetRoles()
        {
            return await db.Role.ToListAsync();
        }

        public async Task MapRoleToUser(string userId, string role)
        {
            var newRoleMapping = new RoleMapping
            {
                UserID = userId,
                RoleName = role,
            };
            await db.AddAsync(newRoleMapping);
            await db.SaveChangesAsync();
        }
    }
}