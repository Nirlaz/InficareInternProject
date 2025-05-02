namespace EmployeeRemitance.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } 
        public string State { get; set; }
        public string District { get; set; } 
        public string Address { get; set; } 
        public string? ZipCode { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; } = "Active";
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
