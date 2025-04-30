using EmployeeRemitance. Interfaces;
using EmployeeRemitance. Models;
using Microsoft. AspNetCore. Mvc;

namespace EmployeeRemitance. Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController ( IEmployeeRepository employeeRepository )
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index ( )
        {
            var Employee = _employeeRepository.GetAllEmployee();
            return View ( Employee );
        }

        public IActionResult Create ( )
        {
            return View ( );
        }

        [HttpPost]
        public IActionResult CreateEmployee ( UpdateModel updateModel )
        {
            var reponse = _employeeRepository. Create ( updateModel );
            if ( reponse. Code == 202 )
            {
                return View ( reponse );
            }
            return BadRequest ( );
        }

        public IActionResult Update ( int Id )
        {
            var employee = _employeeRepository.GetEmployeeById(Id);
            return View ( employee );
        }

        [HttpPost]
        public IActionResult UpdateEmployee ( Employee employee )
        {
            var reponse = _employeeRepository.UpdateEmployee(employee);
            if ( reponse. Code == 202 )
            {
                return RedirectToAction ( "Index" );
            }
            return BadRequest ( );
        }

        public IActionResult DeleteEmployee ( int EmployeeId )
        {

            var reponse = _employeeRepository.DeleteEmployee(EmployeeId);
            if ( reponse. Code == 202 )
            {
                return RedirectToAction ( "Index" );
            }
            return BadRequest ( );
        }
    }
}
