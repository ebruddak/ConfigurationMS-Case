using AutoMapper;
using MongoDB.Driver;
using SettingsConfigurationMS.Dtos;
using SettingsConfigurationMS.Models;
using SettingsConfigurationMS.Settings;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SettingsConfigurationMS.Services;

namespace SettingsConfigurationMS.Services
{
    public class SettingsConfigurationService:ISettingsConfigurationService
    {
        private readonly IMongoCollection<SettingsConfiguration> _confCollection;
        private readonly IMapper _mapper;

        public SettingsConfigurationService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _confCollection = database.GetCollection<SettingsConfiguration>(databaseSettings.CollectionName);
            _mapper = mapper;
        }

        public async Task<Response<List<SettingsConfigurationDto>>> GetAllAsync()
        {
            var SettingsConfigurations = await _confCollection.Find(category => true).ToListAsync();

            return Response<List<SettingsConfigurationDto>>.Success(_mapper.Map<List<SettingsConfigurationDto>>(SettingsConfigurations), 200);
        }

        public async Task<Response<SettingsConfigurationDto>> CreateAsync(SettingsConfigurationDto SettingsConfigurationDto)
        {
            var SettingsConfiguration = _mapper.Map<SettingsConfiguration>(SettingsConfigurationDto);
            await _confCollection.InsertOneAsync(SettingsConfiguration);

            return Response<SettingsConfigurationDto>.Success(_mapper.Map<SettingsConfigurationDto>(SettingsConfiguration), 200);
        }

        public async Task<Response<SettingsConfigurationDto>> GetByIdAsync(string id)
        {
            var SettingsConfiguration = await _confCollection.Find<SettingsConfiguration>(x => x.UUID == id).FirstOrDefaultAsync();

            if (SettingsConfiguration == null)
            {
                return Response<SettingsConfigurationDto>.Fail("SettingsConfiguration not found", 404);
            }

            return Response<SettingsConfigurationDto>.Success(_mapper.Map<SettingsConfigurationDto>(SettingsConfiguration), 200);
        }
        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _confCollection.DeleteOneAsync(x => x.UUID == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("ContactInfo not found", 404);
            }
        }
    }
}
