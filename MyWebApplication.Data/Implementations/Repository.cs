using Dapper;
using MyWebApplication.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public async Task<IEnumerable<T>> QueryAsync(string connectionString, 
                                                     string sql, 
                                                     DynamicParameters parameters, 
                                                     CommandType commandType = CommandType.StoredProcedure, 
                                                     int timeOutInSeconds = 0)
        {
            IEnumerable<T> records;
            using SqlConnection connection = new(connectionString);
            await connection.OpenAsync();
            SqlConnection cnn = connection;
            int? commandTimeout = new int?(timeOutInSeconds);
            records = await cnn.QueryAsync<T>(sql, parameters, commandTimeout: commandTimeout, commandType: commandType);

            return records;
        }

        public async Task<T> QueryFirstOrDefaultAsync(string connectionString, 
                                                      string sql, 
                                                      DynamicParameters parameters, 
                                                      CommandType commandType = CommandType.StoredProcedure, 
                                                      int timeOutInSeconds = 0)
        {
            using SqlConnection connection = new(connectionString);
            await connection.OpenAsync();
            SqlConnection cnn = connection;
            int? commandTimeout = new int?(timeOutInSeconds);
            return parameters != null ?
                    await cnn.QueryFirstOrDefaultAsync<T>(sql, parameters, commandTimeout: commandTimeout, commandType: commandType) :
                      await connection.QueryFirstOrDefaultAsync<T>(sql, commandTimeout: commandTimeout, commandType: commandType);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string connectionString, string sql, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, int timeOutInSeconds = 0)
        {
            SqlMapper.GridReader gridReader;
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            SqlConnection cnn = connection;
            DynamicParameters dynamicParameters = parameters;
            int? commandTimeout = new int?(timeOutInSeconds);
            gridReader = await cnn.QueryMultipleAsync(sql, dynamicParameters, commandTimeout: commandTimeout, commandType: commandType);
            return gridReader;
        }
    }
}
