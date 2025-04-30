using System. Data;
using System. Runtime. CompilerServices;
using EmployeeRemitance. Database;
using EmployeeRemitance. Interfaces;
using EmployeeRemitance. Interfaces. DatabaseInterfaces;
using EmployeeRemitance. Models;
using Microsoft. Data. SqlClient;

namespace EmployeeRemitance. Repository
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly ISQLDbconnect _dbconnect;
        public QualificationRepository (ISQLDbconnect dbconnect )
        {
            _dbconnect = dbconnect;
        }
        public Reponse AddQualification ( Qualification qualification )
        {
            throw new NotImplementedException ( );
        }

        public Reponse DeleteFormEmployeeId ( int QualificationId , int EmployeeId )
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter ( );
            parameters[0]. ParameterName = "@Flag";
            parameters[0]. Value = "ET";
            parameters[0]. SqlDbType = SqlDbType. Char;
            parameters[0]. Size = 2;

            parameters[1] = new SqlParameter ( );
            parameters[1]. ParameterName = "@EmployeeID";
            parameters[1]. Value = EmployeeId;
            parameters[1]. SqlDbType = SqlDbType. Int;

            parameters[2] = new SqlParameter ( );
            parameters[2]. ParameterName = "@QualificationID";
            parameters[2]. Value = QualificationId;
            parameters[2]. SqlDbType = SqlDbType. Int;


            Reponse reponse = _dbconnect.ExecuteSQLDataSingleWithParam<Reponse>("sp_employeequalification",parameters);
            return reponse;
        }

        public Reponse DeleteQualification ( int Id )
        {
            throw new NotImplementedException ( );
        }

        public List<Qualification> GetAllQualification ( )
        {
            throw new NotImplementedException ( );
        }

        public List<Qualification> GetQualificationById ( int EmployeeId )
        {
            SqlParameter[] parameter =new SqlParameter[2];
            parameter[0] = new SqlParameter ( );
            parameter[0]. ParameterName = "@Flag";
            parameter[0]. Value = "EJ";
            parameter[0]. SqlDbType = SqlDbType. Char;
            parameter[0]. Size = 2;

            parameter[1] = new SqlParameter ( );
            parameter[1]. ParameterName = "@EmployeeID";
            parameter[1]. Value = EmployeeId;
            parameter[1]. SqlDbType = SqlDbType. Int;

            var quali = _dbconnect. ExecuteSQLDataListWithParam<Qualification> ( "sp_employeequalification" , parameter );
            return quali;
        }

        public Qualification GetQualificationByQualificationId ( int QualificationId )
        {
            throw new NotImplementedException ( );
        }

        public Reponse UpdateQualification ( Qualification employee )
        {
            throw new NotImplementedException ( );
        }
    }
}
