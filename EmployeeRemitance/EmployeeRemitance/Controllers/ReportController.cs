using System. Net. Cache;
using ClosedXML. Excel;
using EmployeeRemitance. Interfaces;
using EmployeeRemitance. Models;
using Microsoft. AspNetCore. Mvc;

namespace EmployeeRemitance. Controllers
{
    public class ReportController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        public ReportController (IEmployeeRepository employeeRepository )
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index ( FilterModel filter)
        {
            //var filter = new FilterModel
            //{
            //    Employees = new List<Employee>
            //    {
            //      new Employee
            //{
            //    EmployeeID = 1,
            //    FirstName = "John",
            //    MiddleName = "A.",
            //    LastName = "Doe",
            //    DateOfBirth = new DateTime(1990, 1, 1),
            //    Email = "john.doe@example.com",
            //    PhoneNumber = "1234567890",
            //    State = "California",
            //    District = "Los Angeles",
            //    Address = "123 Main St",
            //    ZipCode = "90001",
            //    JobTitle = "Software Developer",
            //    Department = "IT",
            //    Salary = 75000,
            //    CreatedAt = DateTime.Now.AddYears(-3),
            //    UpdatedAt = DateTime.Now
            //},
            //      new Employee
            //{
            //    EmployeeID = 2,
            //    FirstName = "Jane",
            //    MiddleName = "B.",
            //    LastName = "Smith",
            //    DateOfBirth = new DateTime(1985, 5, 10),
            //    Email = "jane.smith@example.com",
            //    PhoneNumber = "2345678901",
            //    State = "Texas",
            //    District = "Houston",
            //    Address = "456 Elm St",
            //    ZipCode = "77001",
            //    JobTitle = "HR Manager",
            //    Department = "HR",
            //    Salary = 85000,
            //    CreatedAt = DateTime.Now.AddYears(-5),
            //    UpdatedAt = DateTime.Now
            //},
            //      new Employee
            //{
            //    EmployeeID = 3,
            //    FirstName = "Michael",
            //    MiddleName = "C.",
            //    LastName = "Brown",
            //    DateOfBirth = new DateTime(1992, 8, 15),
            //    Email = "michael.brown@example.com",
            //    PhoneNumber = "3456789012",
            //    State = "New York",
            //    District = "Manhattan",
            //    Address = "789 Oak St",
            //    ZipCode = "10001",
            //    JobTitle = "Accountant",
            //    Department = "Finance",
            //    Salary = 65000,
            //    CreatedAt = DateTime.Now.AddYears(-2),
            //    UpdatedAt = DateTime.Now
            //}
            //    }
            //};
            return View ( filter );
        }


        [HttpPost]
        public IActionResult ExportExcel ( FilterModel filter )
        {
            var employees = filter.Employees ?? new List<Employee>();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Employees");

            var headers = new[] { "EmployeeID", "FirstName", "MiddleName", "LastName", "DateOfBirth", "Email", "PhoneNumber", "State", "District", "Address", "ZipCode", "JobTitle", "Department", "Salary", "Status", "CreatedAt", "UpdatedAt" };

            for ( int i = 0 ; i < headers. Length ; i++ )
                worksheet. Cell ( 1 , i + 1 ). Value = headers[i];

            for ( int i = 0 ; i < employees. Count ; i++ )
            {
                var emp = employees[i];
                worksheet. Cell ( i + 2 , 1 ). Value = emp. EmployeeID;
                worksheet. Cell ( i + 2 , 2 ). Value = emp. FirstName;
                worksheet. Cell ( i + 2 , 3 ). Value = emp. MiddleName;
                worksheet. Cell ( i + 2 , 4 ). Value = emp. LastName;
                worksheet. Cell ( i + 2 , 5 ). Value = emp. DateOfBirth. ToShortDateString ( );
                worksheet. Cell ( i + 2 , 6 ). Value = emp. Email;
                worksheet. Cell ( i + 2 , 7 ). Value = emp. PhoneNumber;
                worksheet. Cell ( i + 2 , 8 ). Value = emp. State;
                worksheet. Cell ( i + 2 , 9 ). Value = emp. District;
                worksheet. Cell ( i + 2 , 10 ). Value = emp. Address;
                worksheet. Cell ( i + 2 , 11 ). Value = emp. ZipCode;
                worksheet. Cell ( i + 2 , 12 ). Value = emp. JobTitle;
                worksheet. Cell ( i + 2 , 13 ). Value = emp. Department;
                worksheet. Cell ( i + 2 , 14 ). Value = emp. Salary;
                worksheet. Cell ( i + 2 , 15 ). Value = emp. Status;
                worksheet. Cell ( i + 2 , 16 ). Value = emp. CreatedAt;
                worksheet. Cell ( i + 2 , 17 ). Value = emp. UpdatedAt;
            }

            using var stream = new MemoryStream();
            workbook. SaveAs ( stream );
            stream. Position = 0;

            return File ( stream. ToArray ( ) , "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" , "Employees.xlsx" );
        }

        [HttpPost]
        public IActionResult FilterSearch(FilterModel filter )
        {

            if ( filter. DateOfBirth == null && filter. Age != null )
            {
                int dateYear = DateTime.Now.Year - filter.Age.Value;
                filter. DateOfBirth = new DateOnly ( dateYear , 1 , 1 );
                filter. Employees = _employeeRepository. GetByFilter ( filter. DateOfBirth , filter. AccountFrom , filter. AccountTo );
            } else
            {
                filter. Age = filter. DateOfBirth. HasValue
                    ? DateTime. Now. Year - filter. DateOfBirth. Value. Year
                    : 0;
                filter. Employees = _employeeRepository. GetByFilter ( filter. DateOfBirth , filter. AccountFrom , filter. AccountTo );
            }

            return View ( "Index" , filter );

        }
    }
}
