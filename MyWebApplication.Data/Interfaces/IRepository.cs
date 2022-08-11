using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> QueryAsync(string connectionString, 
                                        string sql, 
                                        DynamicParameters parameters, 
                                        CommandType commandType = CommandType.StoredProcedure, 
                                        int timeOutInSeconds = 0);
        Task<T> QueryFirstOrDefaultAsync(string connectionString, 
                                         string sql, 
                                         DynamicParameters parameters, 
                                         CommandType commandType = CommandType.StoredProcedure, 
                                         int timeOutInSeconds = 0);
        Task<SqlMapper.GridReader> QueryMultipleAsync(string connectionString, 
                                                      string sql, 
                                                      DynamicParameters parameters, 
                                                      CommandType commandType = CommandType.StoredProcedure, 
                                                      int timeOutInSeconds = 0);
    }
}
