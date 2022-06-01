using BookService.Application.Interfaces.Configuration;
using BookService.Domain.Parameters;
using BookService.Infrastructure.Constants.Configuration;
using Microsoft.Extensions.Configuration;
using System;

namespace BookService.Infrastructure.Configuration
{
    public class ConfigProvider : IConfigProvider
    {
        private IConfiguration _config;
        private ConfigParameter _configParameter;

        public bool IsDevelopment
        {
            get
            {
                return _config[ConfigKeys.Enviroment.ASPNETCORE_ENVIRONMENT.Key] ==
                    ConfigKeys.Enviroment.ASPNETCORE_ENVIRONMENT.Development;
            }
        }

        public ConfigProvider(IConfiguration config, ConfigParameter configParameter)
        {
            _config = config;
            _configParameter = configParameter;
        }

        public string GetConnectionString()
        {
            return Get(ConfigKeys.ConnectionStringsSectionName, _configParameter.ConnectionName);
        }

        public string Get(string key)
        {
            var value = _config[key];

            if (value == null)
            {
                throw new ArgumentException(string.Format(Error.InvalidKeyFormat, key));
            }

            return value;
        }

        public string Get(string sectionName, string key)
        {
            var path = $"{sectionName}:{key}";

            return Get(path);
        }
    }
}
