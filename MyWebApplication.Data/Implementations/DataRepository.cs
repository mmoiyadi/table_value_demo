using Dapper;
using Microsoft.Extensions.Configuration;
using MyWebApplication.Data.Interfaces;
using MyWebApplication.Models;
using SuperiorSystems.SqlMetaData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Implementations
{
    public class DataRepository : Repository<DataModel>, IDataRepository
    {
        private readonly ISqlMetaDataRepository sqlMetaDataRepository;
        private readonly IConfiguration configuration;

        public DataRepository(ISqlMetaDataRepository sqlMetaDataRepository,
                                IConfiguration configuration)
        {
            this.sqlMetaDataRepository = sqlMetaDataRepository;
            this.configuration = configuration;
        }
        public async Task<DataModel> CreateDataAsync(InputData inputData)
        {
            const string procedureName = "create_data";
            DataModel dataModel = null;
            DynamicParameters parameters = sqlMetaDataRepository.GetProcedureParmetersForObject(procedureName, new
            {
                name = inputData.Name,
                month_id = inputData.MonthId
            });
            try
            {
                dataModel = await QueryFirstOrDefaultAsync(configuration.GetConnectionString("databaseConnection"), procedureName, parameters);
            }catch(SqlException ex)
            {
                throw new Exception("Database Exception: ", ex);
            }
            return dataModel;
        }

        public async Task<IEnumerable<MyDataType>> CreateAndFetchDataAsync(InputData inputData)
        {
            const string procedureName = "create_data_tvp";
            IEnumerable<MyDataType> result;
            DynamicParameters parameters = sqlMetaDataRepository.GetProcedureParmetersForObject(procedureName, new
            {
                month_id = inputData.MonthId
            });
            try
            {
                using var dataWithType = await QueryMultipleAsync(configuration.GetConnectionString("databaseConnection"),
                                                     procedureName, 
                                                     parameters);

                result = await dataWithType.ReadAsync<MyDataType>();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database Exception: ", ex);
            }
            return result;
        }

        public async Task<IEnumerable<MyDataType>> GetDataByIdAsync(int id)
        {
            const string procedureName = "get_data";
            
            IEnumerable<MyDataType> result;
            
            DynamicParameters parameters = sqlMetaDataRepository.GetProcedureParmetersForObject(procedureName, new
            {
                id = id
            });
            try
            {
                using var dataWithType = await QueryMultipleAsync(configuration.GetConnectionString("databaseConnection"),
                                                     procedureName,
                                                     parameters);
                

                result = await dataWithType.ReadAsync<MyDataType>();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database Exception: ", ex);
            }
            return result;
        }

        public async Task<IEnumerable<MyDataType>> CreateAndFetchDataBetweenAsync(InputDataBetween inputData)
        {
            const string procedureName = "get_data_between2";
            IEnumerable<MyDataType> result;
            DynamicParameters parameters = sqlMetaDataRepository.GetProcedureParmetersForObject(procedureName, new
            {
                month1 = inputData.Month1Id,
                month2 = inputData.Month2Id
            });
            try
            {
                using var dataWithType = await QueryMultipleAsync(configuration.GetConnectionString("databaseConnection"),
                                                     procedureName,
                                                     parameters);

                result = await dataWithType.ReadAsync<MyDataType>();
            }
            catch (SqlException ex)
            {
                throw new Exception("Database Exception: ", ex);
            }
            return result;
        }
    }
}
