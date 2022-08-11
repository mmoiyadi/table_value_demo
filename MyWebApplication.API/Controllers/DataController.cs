using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.API.ViewModels;
using MyWebApplication.Models;
using MyWebApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DataController : ControllerBase
    {
        private readonly IDataService dataService;
        private readonly IMapper mapper;

        public DataController(IDataService dataService,
                                IMapper mapper)
        {
            this.dataService = dataService;
            this.mapper = mapper;
        }

        [HttpPost(Name = "CreateData")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DataViewModel>> CreateDataAsync(InputDataViewModel inputDataViewModel)
        {
            var data = await dataService.CreateDataAsync(mapper.Map<InputData>(inputDataViewModel));
            if(data is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return CreatedAtRoute("GetDataById", new { id = data.Id }, data);
        }

        [HttpPost("fetch", Name = "CreateAndFetchData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MyDataTypeViewModel>>> CreateAndFetchDataAsync(InputDataViewModel inputDataViewModel)
        {
            var data = await dataService.CreateAndFetchDataAsync(mapper.Map<InputData>(inputDataViewModel));
            if (data is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(mapper.Map<IEnumerable<MyDataTypeViewModel>>(data));
        }

        [HttpPost("fetchBetween", Name = "CreateAndFetchDataBetween")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MyDataTypeViewModel>>> CreateAndFetchDataBetweenAsync(InputDataBetweenViewModel inputDataViewModel)
        {
            var data = await dataService.CreateAndFetchDataBetweenAsync(mapper.Map<InputDataBetween>(inputDataViewModel));
            if (data is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(mapper.Map<IEnumerable<MyDataTypeViewModel>>(data));
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}", Name = "GetDataById")]
        public async Task<ActionResult<DataViewModel>> GetDataById(int id)
        {
            var data = await dataService.GetDataByIdAsync(id);

            if (data is null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<IEnumerable<MyDataTypeViewModel>>(data));
        }
    }
}
