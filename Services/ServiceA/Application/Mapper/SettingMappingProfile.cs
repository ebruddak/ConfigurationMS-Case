using AutoMapper;
using Application.Commands.SettingCreateCommand;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{

    public class SettingMappingProfile : Profile
    {
        public SettingMappingProfile()
        {
            CreateMap<Setting, SettingCreateCommand>().ReverseMap();
            CreateMap<Setting, SettingResponse>().ReverseMap();


        }
    }
}