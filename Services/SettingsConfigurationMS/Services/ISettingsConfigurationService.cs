using SettingsConfigurationMS.Dtos;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SettingsConfigurationMS.Services
{
    public interface ISettingsConfigurationService
    {
        Task<Response<List<SettingsConfigurationDto>>> GetAllAsync();

        Task<Response<SettingsConfigurationDto>> CreateAsync(SettingsConfigurationDto category);

        Task<Response<SettingsConfigurationDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> DeleteAsync(string id);
        Task<T> GetValue<T>(string key);
    }
}
