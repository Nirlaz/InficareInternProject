using EmployeeRemitance. Models;

namespace EmployeeRemitance. Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployee ( );

        List<Employee>? GetByFilter ( DateOnly? DateOfBirth , DateTime? AccountFrom , DateTime? AccountTo );
        Reponse Create(UpdateModel model);

        Employee GetEmployeeById ( int id);

        Reponse UpdateEmployee ( Employee employee );

        Reponse DeleteEmployee ( int EmployeeId );
    }
}
