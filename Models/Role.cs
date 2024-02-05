using System.ComponentModel.DataAnnotations;

namespace EMS_Portal_Nomination.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator Role(List<Role> v)
        {
            throw new NotImplementedException();
        }
    }
}
