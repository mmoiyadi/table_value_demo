using AutoMapper;
using MyWebApplication.API.ViewModels;
using MyWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.API.Profiles
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<DataViewModel, DataModel>().ReverseMap();
            CreateMap<InputDataViewModel, InputData>().ReverseMap();
            CreateMap<InputDataBetweenViewModel, InputDataBetween>().ReverseMap();
            CreateMap<MyDataType, MyDataTypeViewModel>()
                    .ForMember(x => x.Int1, y => y.MapFrom(z => z.Int1))
                    .ForMember(x => x.Int2, y => y.MapFrom(z => z.Int2))
                    .ForMember(x => x.Int3, y => y.MapFrom(z => z.Int3))
                    .ForMember(x => x.Str1, y => y.MapFrom(z => z.Str1))
                    .ForMember(x => x.Str2, y => y.MapFrom(z => z.Str2))
                    .ForMember(x => x.Str3, y => y.MapFrom(z => z.Str3))
                    .ForMember(x => x.Date1, y => y.MapFrom(z => z.Date1))
                    .ForMember(x => x.Date2, y => y.MapFrom(z => z.Date2))
                    .ForMember(x => x.Date3, y => y.MapFrom(z => z.Date3)).ReverseMap();
        }
        
    }
}
