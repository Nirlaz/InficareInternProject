using System. Net. Cache;
using ClosedXML. Excel;
using DocumentFormat. OpenXml. Drawing. Diagrams;
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
                filter. Employees = _employeeRepository. GetByFilter (filter);
                filter. AgeFrom = null;
                filter. AgeTo = null;
                filter. AccountFrom = null;
                filter. AccountTo = null;
                return View ("Index" , filter );

        }
    }
}
