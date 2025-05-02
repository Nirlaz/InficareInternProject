using System. Data;
using System. Reflection;
using EmployeeRemitance. Interfaces;
using EmployeeRemitance. Interfaces. DatabaseInterfaces;
using EmployeeRemitance. Models;
using Microsoft. Data. SqlClient;

namespace EmployeeRemitance. Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISQLDbconnect _connection;
        public EmployeeRepository (ISQLDbconnect connection )
        {
            _connection = connection;  
        }

        public Reponse Create ( UpdateModel model )
        {
            SqlParameter[] parameters = new SqlParameter[15];
            parameters[0] = new SqlParameter ( );
            parameters[0]. ParameterName = "@Flag";
            parameters[0]. Value = "EI";
            parameters[0]. SqlDbType = SqlDbType. Char;
            parameters[0]. Size = 2;

            parameters[1] = new SqlParameter ( );
            parameters[1]. ParameterName = "@FirstName";
            parameters[1]. Value = model. Employee. FirstName;
            parameters[1]. SqlDbType = SqlDbType. VarChar;
            parameters[1]. Size = 50;

            parameters[2] = new SqlParameter ( );
            parameters[2]. ParameterName = "@MiddleName";
            parameters[2]. Value = model. Employee. MiddleName;
            parameters[2]. SqlDbType = SqlDbType. VarChar;
            parameters[2]. Size = 50;

            parameters[3] = new SqlParameter ( );
            parameters[3]. ParameterName = "@LastName";
            parameters[3]. Value = model. Employee. LastName;
            parameters[3]. SqlDbType = SqlDbType. VarChar;
            parameters[3]. Size = 50;

            parameters[4] = new SqlParameter ( );
            parameters[4]. ParameterName = "@DateOfBirth";
            parameters[4]. Value = model. Employee. DateOfBirth;
            parameters[4]. SqlDbType = SqlDbType. Date;

            parameters[5] = new SqlParameter ( );
            parameters[5]. ParameterName = "@Email";
            parameters[5]. Value = model. Employee. Email;
            parameters[5]. SqlDbType = SqlDbType. VarChar;
            parameters[5]. Size = 100;

            parameters[6] = new SqlParameter ( );
            parameters[6]. ParameterName = "@PhoneNumber";
            parameters[6]. Value = model. Employee. PhoneNumber;
            parameters[6]. SqlDbType = SqlDbType. VarChar;
            parameters[6]. Size = 20;

            parameters[7] = new SqlParameter ( );
            parameters[7]. ParameterName = "@State";
            parameters[7]. Value = model. Employee. State;
            parameters[7]. SqlDbType = SqlDbType. VarChar;
            parameters[7]. Size = 50;

            parameters[8] = new SqlParameter ( );
            parameters[8]. ParameterName = "@District";
            parameters[8]. Value = model. Employee. District;
            parameters[8]. SqlDbType = SqlDbType. VarChar;
            parameters[8]. Size = 50;

            parameters[9] = new SqlParameter ( );
            parameters[9]. ParameterName = "@Address";
            parameters[9]. Value = model. Employee. Address;
            parameters[9]. SqlDbType = SqlDbType. VarChar;
            parameters[9]. Size = 255;

            parameters[10] = new SqlParameter ( );
            parameters[10]. ParameterName = "@ZipCode";
            parameters[10]. Value = model. Employee. ZipCode;
            parameters[10]. SqlDbType = SqlDbType. VarChar;
            parameters[10]. Size = 10;

            parameters[11] = new SqlParameter ( );
            parameters[11]. ParameterName = "@JobTitle";
            parameters[11]. Value = model. Employee. JobTitle;
            parameters[11]. SqlDbType = SqlDbType. VarChar;
            parameters[11]. Size = 100;

            parameters[12] = new SqlParameter ( );
            parameters[12]. ParameterName = "@Department";
            parameters[12]. Value = model. Employee. Department;
            parameters[12]. SqlDbType = SqlDbType. VarChar;
            parameters[12]. Size = 100;

            parameters[13] = new SqlParameter ( );
            parameters[13]. ParameterName = "@Salary";
            parameters[13]. Value = model. Employee. Salary;
            parameters[13]. SqlDbType = SqlDbType. Decimal;

            parameters[14] = new SqlParameter ( );
            parameters[14]. ParameterName = "@Status";
            parameters[14]. Value = model. Employee. Status;
            parameters[14]. SqlDbType = SqlDbType. VarChar;
            parameters[14]. Size = 20;

            var result = _connection.ExecuteSQLDataSingleWithParam<Reponse>("sp_employee",parameters);
            foreach ( var item in model. QualificationsId )
            {
                SqlParameter[] parameters1 = new SqlParameter[3];
                parameters1[0] = new SqlParameter ( );
                parameters1[0]. ParameterName = "@Flag";
                parameters1[0]. Value = "i";
                parameters1[0]. SqlDbType = SqlDbType. Char;
                parameters1[0]. Size = 2;

                parameters1[1] = new SqlParameter ( );
                parameters1[1]. ParameterName = "@EmployeeID";
                parameters1[1]. Value = result. EmployeeID;
                parameters1[1]. SqlDbType = SqlDbType. VarChar;
                parameters1[1]. Size = 24;

                parameters1[2] = new SqlParameter ( );
                parameters1[2]. ParameterName = "@QualificationId";
                parameters1[2]. Value = item;
                parameters1[2]. SqlDbType = SqlDbType. VarChar;
                parameters1[2]. Size = 24;
                var reponse = _connection.ExecuteSQLDataSingleWithParam<Reponse>("sp_employeequalification",parameters1);
            }


            return result;
        
        }

        public Reponse DeleteEmployee ( int EmployeeId )
        {
            SqlParameter[] parameter = new SqlParameter[2];

            parameter[0] = new SqlParameter ( );
            parameter[0]. ParameterName = "@Flag";
            parameter[0]. Value = "ED";
            parameter[0]. SqlDbType = SqlDbType. Char;
            parameter[0]. Size = 2;

            parameter[1] = new SqlParameter ( );
            parameter[1]. ParameterName = "@EmployeeID";
            parameter[1]. Value = EmployeeId;
            parameter[1]. SqlDbType = SqlDbType. Int;
            return _connection. ExecuteSQLDataSingleWithParam<Reponse> ( "SP_NEWEMPLOYEE" , parameter );
        }

        public List<Employee> GetAllEmployee ( )
        {
            SqlParameter[] parameter = new SqlParameter[1];

            parameter[0] = new SqlParameter ( );
            parameter[0]. ParameterName = "@Flag";
            parameter[0]. Value = "ES";
            parameter[0]. SqlDbType = SqlDbType. Char;
            parameter[0]. Size = 2;
            return _connection. ExecuteSQLDataListWithParam<Employee> ( "SP_NEWEMPLOYEE" , parameter );
        }

        public List<Employee> GetByFilter ( FilterModel filterModel )
        {
            SqlParameter[] parameter = new SqlParameter[7];

            parameter[0] = new SqlParameter ( );
            parameter[0]. ParameterName = "@Flag";
            parameter[0]. Value = "EF";
            parameter[0]. SqlDbType = SqlDbType. Char;
            parameter[0]. Size = 2;

            parameter[1] = new SqlParameter ( );
            parameter[1]. ParameterName = "@CreatedFrom";
            parameter[1]. Value = ( object? ) filterModel.AccountFrom ?? DBNull. Value;
            parameter[1]. SqlDbType = SqlDbType. DateTime;
           

            parameter[2] = new SqlParameter ( );
            parameter[2]. ParameterName = "@CreatedTo";
            parameter[2]. Value = ( object? ) filterModel. AccountTo ?? DBNull. Value;
            parameter[2]. SqlDbType = SqlDbType. DateTime;
            

            parameter[3] = new SqlParameter ( );
            parameter[3]. ParameterName = "@AgeFrom";
            parameter[3]. Value = ( object? ) filterModel. AgeFrom;
            parameter[3]. SqlDbType = SqlDbType. Int;

            parameter[4] = new SqlParameter ( );
            parameter[4]. ParameterName = "@AgeTo";
            parameter[4]. Value = ( object? ) filterModel. AgeTo;
            parameter[4]. SqlDbType = SqlDbType. Int;

            parameter[5] = new SqlParameter ( );
            parameter[5]. ParameterName = "@PhoneNumber";
            parameter[5]. Value = ( object? ) filterModel. PhoneNumber;
            parameter[5]. SqlDbType = SqlDbType. VarChar;
            parameter[5]. Size = 20;


            parameter[6] = new SqlParameter ( );
            parameter[6]. ParameterName = "@ZipCode";
            parameter[6]. Value = ( object? ) filterModel. ZipCode;
            parameter[6]. SqlDbType = SqlDbType. VarChar;
            parameter[6]. Size = 10;

            var Employee =  _connection. ExecuteSQLDataListWithParam<Employee> ( "SP_NEWEMPLOYEE" , parameter );
            return Employee;
        }

        public Employee GetEmployeeById ( int id )
        {
            SqlParameter[] parameter = new SqlParameter[2];

            parameter[0] = new SqlParameter ( );
            parameter[0]. ParameterName = "@Flag";
            parameter[0]. Value = "EE";
            parameter[0]. SqlDbType = SqlDbType. Char;
            parameter[0]. Size = 2;

            parameter[1] = new SqlParameter ( );
            parameter[1]. ParameterName = "@EmployeeID";
            parameter[1]. Value = id;
            parameter[1]. SqlDbType = SqlDbType. Int;
            return _connection. ExecuteSQLDataSingleWithParam<Employee> ( "SP_NEWEMPLOYEE" , parameter );
        }

        public Reponse UpdateEmployee ( Employee Employee )
        {
            SqlParameter[] parameters = new SqlParameter[16];

            parameters[0] = new SqlParameter ( );
            parameters[0]. ParameterName = "@Flag";
            parameters[0]. Value = "EU";
            parameters[0]. SqlDbType = SqlDbType. Char;
            parameters[0]. Size = 2;

            parameters[1] = new SqlParameter ( );
            parameters[1]. ParameterName = "@FirstName";
            parameters[1]. Value = Employee. FirstName;
            parameters[1]. SqlDbType = SqlDbType. VarChar;
            parameters[1]. Size = 50;

            parameters[2] = new SqlParameter ( );
            parameters[2]. ParameterName = "@MiddleName";
            parameters[2]. Value =  Employee. MiddleName;
            parameters[2]. SqlDbType = SqlDbType. VarChar;
            parameters[2]. Size = 50;

            parameters[3] = new SqlParameter ( );
            parameters[3]. ParameterName = "@LastName";
            parameters[3]. Value =  Employee. LastName;
            parameters[3]. SqlDbType = SqlDbType. VarChar;
            parameters[3]. Size = 50;

            parameters[4] = new SqlParameter ( );
            parameters[4]. ParameterName = "@DateOfBirth";
            parameters[4]. Value =  Employee. DateOfBirth;
            parameters[4]. SqlDbType = SqlDbType. Date;

            parameters[5] = new SqlParameter ( );
            parameters[5]. ParameterName = "@Email";
            parameters[5]. Value =  Employee. Email;
            parameters[5]. SqlDbType = SqlDbType. VarChar;
            parameters[5]. Size = 100;

            parameters[6] = new SqlParameter ( );
            parameters[6]. ParameterName = "@PhoneNumber";
            parameters[6]. Value =  Employee. PhoneNumber;
            parameters[6]. SqlDbType = SqlDbType. VarChar;
            parameters[6]. Size = 20;

            parameters[7] = new SqlParameter ( );
            parameters[7]. ParameterName = "@State";
            parameters[7]. Value =  Employee. State;
            parameters[7]. SqlDbType = SqlDbType. VarChar;
            parameters[7]. Size = 50;

            parameters[8] = new SqlParameter ( );
            parameters[8]. ParameterName = "@District";
            parameters[8]. Value =  Employee. District;
            parameters[8]. SqlDbType = SqlDbType. VarChar;
            parameters[8]. Size = 50;

            parameters[9] = new SqlParameter ( );
            parameters[9]. ParameterName = "@Address";
            parameters[9]. Value = Employee. Address;
            parameters[9]. SqlDbType = SqlDbType. VarChar;
            parameters[9]. Size = 255;

            parameters[10] = new SqlParameter ( );
            parameters[10]. ParameterName = "@ZipCode";
            parameters[10]. Value =  Employee. ZipCode;
            parameters[10]. SqlDbType = SqlDbType. VarChar;
            parameters[10]. Size = 10;

            parameters[11] = new SqlParameter ( );
            parameters[11]. ParameterName = "@JobTitle";
            parameters[11]. Value =  Employee. JobTitle;
            parameters[11]. SqlDbType = SqlDbType. VarChar;
            parameters[11]. Size = 100;

            parameters[12] = new SqlParameter ( );
            parameters[12]. ParameterName = "@Department";
            parameters[12]. Value =  Employee. Department;
            parameters[12]. SqlDbType = SqlDbType. VarChar;
            parameters[12]. Size = 100;

            parameters[13] = new SqlParameter ( );
            parameters[13]. ParameterName = "@Salary";
            parameters[13]. Value = Employee. Salary;
            parameters[13]. SqlDbType = SqlDbType. Decimal;

            parameters[14] = new SqlParameter ( );
            parameters[14]. ParameterName = "@Status";
            parameters[14]. Value = Employee. Status;
            parameters[14]. SqlDbType = SqlDbType. VarChar;
            parameters[14]. Size = 20;

            parameters[15] = new SqlParameter ( );
            parameters[15]. ParameterName = "@EmployeeID";
            parameters[15]. Value = Employee. EmployeeID;
            parameters[15]. SqlDbType = SqlDbType. Int;


            var reponse = _connection.ExecuteSQLDataSingleWithParam<Reponse>("SP_NEWEMPLOYEE",parameters);
            return reponse;
        }
    }
}
