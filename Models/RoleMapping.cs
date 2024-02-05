using System.ComponentModel.DataAnnotations;

namespace EMS_Portal_Nomination.Models
{
    public class RoleMapping
    {
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }
        public string RoleName { get; set; }

    }
}
