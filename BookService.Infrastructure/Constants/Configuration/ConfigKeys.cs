using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Infrastructure.Constants.Configuration
{
    public class ConfigKeys
    {
        public const string ConnectionStringsSectionName = "ConnectionStrings";
        
        public class Enviroment
        {
            public class ASPNETCORE_ENVIRONMENT
            {
                public const string Key = "ASPNETCORE_ENVIRONMENT";
                public const string Development = "Development";
            }
        }
    }
}
