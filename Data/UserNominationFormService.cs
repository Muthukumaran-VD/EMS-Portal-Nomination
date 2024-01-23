using EMS_Portal_Nomination.Context;
using System.Data.Entity;

namespace EMS_Portal_Nomination.Data
{
    public class UserNominationFormService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserNominationFormService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<UserNominationForm>> GetAllUserNominationFormData()
        {
            return await _applicationDbContext.NominationFormByUser.ToListAsync();
        }

        public async Task<bool> AddUserNominationFormData(UserNominationForm userNominationForm)
        {
            await _applicationDbContext.NominationFormByUser.AddAsync(userNominationForm);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserNominationFormData(UserNominationForm userNominationForm)
        {
            _applicationDbContext.NominationFormByUser.Update(userNominationForm);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserNominationFormData(UserNominationForm userNominationForm)
        {
            _applicationDbContext.NominationFormByUser.Remove(userNominationForm);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
    }
}
