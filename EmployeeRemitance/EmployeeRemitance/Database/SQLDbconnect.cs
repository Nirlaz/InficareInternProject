using System. Data;
using EmployeeRemitance. Interfaces. DatabaseInterfaces;
using Microsoft. Data. SqlClient;

namespace EmployeeRemitance. Database
{
    public class SQLDbconnect:ISQLDbconnect
    {
        private readonly IConfiguration _configuration;
        public SQLDbconnect ( IConfiguration configuration )
        {
            _configuration = configuration;

        }
        private string GetConnectionString ( )
        {
            return _configuration. GetConnectionString ( "DefaultConnection" );
        }

        public List<T> ExecuteSQLDataListWithParam<T> ( string sql , SqlParameter[] sqlParameters ) where T : new()
        {
            var results = new List<T>();

            using ( SqlConnection connection = new SqlConnection ( GetConnectionString ( ) ) )
            using ( SqlCommand cmd = connection. CreateCommand ( ) )
            {
                connection. Open ( );
                cmd. CommandText = sql;
                cmd. CommandType = CommandType. StoredProcedure;

                foreach ( SqlParameter item in sqlParameters )
                {
                    cmd. Parameters. Add ( item );
                }

                using ( SqlDataAdapter da = new SqlDataAdapter ( cmd ) )
                {
                    DataTable dt = new DataTable();
                    da. Fill ( dt );

                    if ( dt. Rows. Count > 0 )
                    {
                        foreach ( DataRow row in dt. Rows )
                        {
                            T obj = new T();
                            foreach ( var prop in typeof ( T ). GetProperties ( ) )
                            {
                                if ( dt. Columns. Contains ( prop. Name ) && row[prop. Name] != DBNull. Value )
                                {
                                    prop. SetValue ( obj , Convert. ChangeType ( row[prop. Name] , prop. PropertyType ) );
                                }
                            }
                            results. Add ( obj );
                        }
                    }
                }
            }

            return results;
        }

        public T ExecuteSQLDataSingleWithParam<T> ( string sql , SqlParameter[] sqlParameters ) where T : new()
        {
            var results = new List<T>();

            using ( SqlConnection connection = new SqlConnection ( GetConnectionString ( ) ) )
            using ( SqlCommand cmd = connection. CreateCommand ( ) )
            {
                connection. Open ( );
                cmd. CommandText = sql;
                cmd. CommandType = CommandType. StoredProcedure;

                foreach ( SqlParameter item in sqlParameters )
                {
                    cmd. Parameters. Add ( item );
                }

                using ( SqlDataAdapter da = new SqlDataAdapter ( cmd ) )
                {
                    DataTable dt = new DataTable();
                    da. Fill ( dt );
                    if ( dt. Rows. Count > 0 )
                    {
                        foreach ( DataRow row in dt. Rows )
                        {
                            T obj = new T();
                            foreach ( var prop in typeof ( T ). GetProperties ( ) )
                            {
                                if ( dt. Columns. Contains ( prop. Name ) && row[prop. Name] != DBNull. Value )
                                {
                                    prop. SetValue ( obj , Convert. ChangeType ( row[prop. Name] , prop. PropertyType ) );
                                }
                            }
                            results. Add ( obj );
                        }
                    }

                }
            }

            return results. FirstOrDefault ( );
        }



    }
}
