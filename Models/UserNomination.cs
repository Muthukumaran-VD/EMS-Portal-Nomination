using System.ComponentModel.DataAnnotations;

namespace EMS_Portal_Nomination.Models
{
    public class UserNomination
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }  
        public string EmailId { get; set; }
        public int ProjectsWorked { get; set; }
        public int TechnologiesWorked { get; set; }
        public string OutsideParticipation { get; set; }
        public string OtherProjects { get; set; }
        public string HighestWorkingHours { get; set; }
        public string? AwardNomination { get; set; }
        public string Remarks { get; set; }
        public string Role { get; set; }
        public string ReportingTo { get; set; }
    }
}
