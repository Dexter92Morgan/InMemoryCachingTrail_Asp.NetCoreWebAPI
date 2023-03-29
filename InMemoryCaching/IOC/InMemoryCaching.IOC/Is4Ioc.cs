using InMemoryCaching.Domain.Interfaces.BussinessInterfaces;
using InMemoryCaching.Domain.Interfaces.RepositoryInterfaces;
using InMemoryCaching.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryCaching.IOC
{
    public static class Is4Ioc
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeServices>();
            services.AddTransient<IEmployeeRepository, Repositories.Repositories.EmployeeRepository>();
        }
    }
}
