using AutoMapper;
using SettingsConfigurationMS.Dtos;
using SettingsConfigurationMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Events;
namespace SettingsConfigurationMS.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<SettingsConfiguration, SettingsConfigurationDto>().ReverseMap();
            CreateMap<SettingsConfiguration, SettingsConfigurationCreateDto>().ReverseMap();
            CreateMap<SettingsConfiguration, SettingsConfigurationUpdateDto>().ReverseMap();
            CreateMap<ConfigurationCreateEvent, SettingsConfigurationDto>().ReverseMap();


        }
    }
}
