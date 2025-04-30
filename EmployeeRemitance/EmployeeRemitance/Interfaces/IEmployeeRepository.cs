using EmployeeRemitance. Models;

namespace EmployeeRemitance. Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployee ( );

        Reponse Create(UpdateModel model);

        Employee GetEmployeeById ( int id);

        Reponse UpdateEmployee ( Employee employee );

        Reponse DeleteEmployee ( int EmployeeId );
    }
}
