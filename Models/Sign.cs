using System.ComponentModel.DataAnnotations;

namespace EMS_Portal_Nomination.Models
{
    public class Sign
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }


    }
}
