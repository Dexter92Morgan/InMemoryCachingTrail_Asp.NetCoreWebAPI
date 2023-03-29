using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCaching.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            Is4Ioc.RegisterService(services);
        }
    }
}
