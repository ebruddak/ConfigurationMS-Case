using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettingsConfigurationMS.Dtos
{
    public class SettingsConfigurationDto
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }
        public string ApplicationName { get; set; }
    }
}
