
using Microsoft.AspNetCore.Mvc;
using Moq;
using SettingsConfigurationMS.Controllers;
using SettingsConfigurationMS.Models;
using SettingsConfigurationMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Controllers
{
    public class SettingControllerTest
    {
        private readonly Mock<ISettingsConfigurationService> _mockRepo;
        private readonly SettingsConfigurationController _controller;
        private SettingsConfiguration settings;

        public SettingControllerTest()
        {
            _mockRepo = new Mock<ISettingsConfigurationService>();
            _controller = new SettingsConfigurationController(_mockRepo.Object);
          
                new SettingsConfiguration{
                          UUID= "61f5c155fd58771086867b50",
                          Name="Ebruli",
                          Type= "Ebru",
                          IsActive= true
                          },
            };
        }
        [Fact]
        public async void CreateSetting_ActionExecutes_ReturnSettings()
        {
            _mockRepo.Setup(x => x.GetAllAsync());

            var result = await _controller.Create();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var SettingsConfigurationReturn = Assert.IsAssignableFrom<IEnumerable<SettingsConfiguration>>(okResult.Value);
            Assert.Equal<int>(1, SettingsConfigurationReturn.ToList().Count);
        }
    }
}