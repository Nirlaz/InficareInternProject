using EmployeeRemitance. Models;

namespace EmployeeRemitance. Interfaces
{
    public interface IQualificationRepository
    {
        Reponse UpdateQualification ( Qualification employee );

        Reponse DeleteQualification ( int Id );
        Reponse DeleteFormEmployeeId ( int QualificationId , int EmployeeId );

        List<Qualification> GetAllQualification ( );
        List<Qualification> GetQualificationById ( int EmployeeId );
        Qualification GetQualificationByQualificationId ( int QualificationId );
        Reponse AddQualification ( Qualification qualification );
    }
}
