using System. Net. Cache;

namespace EmployeeRemitance. Models
{
    public class FilterModel
    {
        public Employee? Employee { get; set; }
        public List<Employee>? Employees { get; set; }
        public int? AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        public DateTime? AccountFrom { get; set; }
        public DateTime? AccountTo { get; set; }

        public string? PhoneNumber { get; set; }

        public string? ZipCode { get; set; }


        public bool DataAvailable { get; set; } = false;
     } 
}
