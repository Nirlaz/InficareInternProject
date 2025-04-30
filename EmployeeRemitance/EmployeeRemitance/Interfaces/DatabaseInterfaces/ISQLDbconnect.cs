using Microsoft. Data. SqlClient;

namespace EmployeeRemitance. Interfaces. DatabaseInterfaces
{
    public interface ISQLDbconnect
    {
        List<T> ExecuteSQLDataListWithParam<T> ( string sql , SqlParameter[] sqlParameters ) where T : new();

        T ExecuteSQLDataSingleWithParam<T> ( string sql , SqlParameter[] sqlParameters ) where T : new();
    }
}
