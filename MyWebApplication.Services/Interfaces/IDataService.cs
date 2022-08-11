using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApplication.Services.Interfaces
{
    public interface IDataService
    {
        Task<DataModel> CreateDataAsync(InputData inputData);
        Task<IEnumerable<MyDataType>> CreateAndFetchDataAsync(InputData inputData);
        Task<IEnumerable<MyDataType>> CreateAndFetchDataBetweenAsync(InputDataBetween inputData);
        Task<IEnumerable<MyDataType>> GetDataByIdAsync(int id);
    }
}
