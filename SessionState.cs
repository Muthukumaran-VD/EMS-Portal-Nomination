using EMS_Portal_Nomination.Models;

namespace EMS_Portal_Nomination
{
    public class SessionState
    {
        public int Id { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
