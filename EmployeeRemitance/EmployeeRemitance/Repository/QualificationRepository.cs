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
            SqlParameter[] parameter =new SqlParameter[2];
            parameter[0] = new SqlParameter ( );
            parameter[0]. ParameterName = "@Flag";
            parameter[0]. Value = "QI";
            parameter[0]. SqlDbType = SqlDbType. Char;
            parameter[0]. Size = 2;

            parameter[1] = new SqlParameter ( );
            parameter[1]. ParameterName = "@QualificationName";
            parameter[1]. Value = qualification. QualificationName;
            parameter[1]. SqlDbType = SqlDbType. VarChar;
            parameter[1]. Size = 255;

            var quali = _dbconnect. ExecuteSQLDataSingleWithParam<Reponse> ( "SP_QUALIFICATION" , parameter );
            return quali;
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
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter ( );
            parameters[0]. ParameterName = "@Flag";
            parameters[0]. Value = "QD";
            parameters[0]. SqlDbType = SqlDbType. Char;
            parameters[0]. Size = 2;

            parameters[1] = new SqlParameter ( );
            parameters[1]. ParameterName = "@qualificationId";
            parameters[1]. Value = Id;
            parameters[1]. SqlDbType = SqlDbType. Int;


            var reponse = _dbconnect.ExecuteSQLDataSingleWithParam<Reponse>("SP_QUALIFICATION",parameters);
            return reponse;
        }

        public List<Qualification> GetAllQualification ( )
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter ( );
            parameters[0]. ParameterName = "@Flag";
            parameters[0]. Value = "QS";
            parameters[0]. SqlDbType = SqlDbType. Char;
            parameters[0]. Size = 2;
            var  qualification = _dbconnect.ExecuteSQLDataListWithParam<Qualification>("SP_QUALIFICATION",parameters);
            return qualification;
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
            SqlParameter[] parameter =new SqlParameter[2];
            parameter[0] = new SqlParameter ( );
            parameter[0]. ParameterName = "@Flag";
            parameter[0]. Value = "QE";
            parameter[0]. SqlDbType = SqlDbType. Char;
            parameter[0]. Size = 2;

            parameter[1] = new SqlParameter ( );
            parameter[1]. ParameterName = "@QualificationId";
            parameter[1]. Value = QualificationId;
            parameter[1]. SqlDbType = SqlDbType. Int;

            var quali = _dbconnect. ExecuteSQLDataSingleWithParam<Qualification> ( "SP_QUALIFICATION" , parameter );
            return quali;
        }

        public Reponse UpdateQualification ( Qualification qualification )
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter ( );
            parameters[0]. ParameterName = "@Flag";
            parameters[0]. Value = "QU";
            parameters[0]. SqlDbType = SqlDbType. Char;
            parameters[0]. Size = 2;

            parameters[1] = new SqlParameter ( );
            parameters[1]. ParameterName = "@QualificationId";
            parameters[1]. Value = qualification. QualificationId;
            parameters[1]. SqlDbType = SqlDbType. Int;


            parameters[2] = new SqlParameter ( );
            parameters[2]. ParameterName = "@QualificationName";
            parameters[2]. Value = qualification. QualificationName;
            parameters[2]. SqlDbType = SqlDbType. VarChar;
            parameters[2]. Size = 24;

            var reponse = _dbconnect.ExecuteSQLDataSingleWithParam<Reponse>("SP_QUALIFICATION",parameters);
            return reponse;
        }
    }
}
