using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SettingsConfigurationMS.Dtos;
using SettingsConfigurationMS.Services;
using Shared.ControllerBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Core;
using EventBus.Events;
using EventBus.Producer;
using EventBus.Core;
using AutoMapper;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsConfigurationsController : CustomBaseController
    {
        private readonly ISettingsConfigurationService _settingsConfigurationService;
      
        private readonly EventBusRabbitMQProducer _eventBus;

        private readonly IMapper _mapper;


        public SettingsConfigurationsController(ISettingsConfigurationService SettingsConfigurationService, IMapper mapper, EventBusRabbitMQProducer eventBus)
        {
            _settingsConfigurationService = SettingsConfigurationService;
            _mapper = mapper;
            _eventBus = eventBus;


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var settingsConfigurationDto = await _settingsConfigurationService.GetAllAsync();

            return CreateActionResultInstance(settingsConfigurationDto);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var settingsConfigurationDto = await _settingsConfigurationService.GetByIdAsync(id);

            return CreateActionResultInstance(settingsConfigurationDto);
        }

        [Route("/api/[controller]/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(SettingsConfigurationDto settingsConfigurationDto)
        {
            var response = await _settingsConfigurationService.CreateAsync(settingsConfigurationDto);


            try
            {
                ConfigurationCreateEvent eventMessage = _mapper.Map<ConfigurationCreateEvent>(settingsConfigurationDto);

                _eventBus.Publish(EventBusConstants.ConfigurationCreateQueue, eventMessage);
            }
            catch (Exception ex)
            {
                throw;
            }

            return CreateActionResultInstance(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _settingsConfigurationService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
