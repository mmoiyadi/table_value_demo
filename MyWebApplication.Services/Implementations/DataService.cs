using Microsoft.Extensions.Configuration;
using MyWebApplication.Data.Interfaces;
using MyWebApplication.Models;
using MyWebApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebApplication.Services
{
    public class DataService : IDataService
    {
        private readonly IDataRepository dataRepository;
        private readonly IConfiguration configuration;

        public DataService(IDataRepository dataRepository, IConfiguration configuration )
        {
            this.dataRepository = dataRepository;
            this.configuration = configuration;
        }

        public async Task<IEnumerable<MyDataType>> CreateAndFetchDataAsync(InputData inputData)
        {
            return await dataRepository.CreateAndFetchDataAsync(inputData);
        }

        public async Task<IEnumerable<MyDataType>> CreateAndFetchDataBetweenAsync(InputDataBetween inputData)
        {
            return await dataRepository.CreateAndFetchDataBetweenAsync(inputData);
        }

        public async Task<DataModel> CreateDataAsync(InputData inputData)
        {
            return await dataRepository.CreateDataAsync(inputData);
        }

        public async Task<IEnumerable<MyDataType>> GetDataByIdAsync(int id)
        {
            return await dataRepository.GetDataByIdAsync(id);
        }

        
    }
}
