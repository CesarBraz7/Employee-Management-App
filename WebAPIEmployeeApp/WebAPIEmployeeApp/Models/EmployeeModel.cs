using System.ComponentModel.DataAnnotations;
using WebAPIEmployeeApp.Enums;

namespace WebAPIEmployeeApp.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool IsActive { get; set; }
        public ShiftEnum Shift { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime UpdateDate { get; set; } = DateTime.Now.ToLocalTime();

    }
}
