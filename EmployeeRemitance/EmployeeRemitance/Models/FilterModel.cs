using System. Net. Cache;

namespace EmployeeRemitance. Models
{
    public class FilterModel
    {
        public Employee? Employee { get; set; }
        public List<Employee>? Employees { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public DateTime? AccountFrom { get; set; }
        public DateTime? AccountTo { get; set; }

        public int? Age { get; set; }
    }                                        
}
