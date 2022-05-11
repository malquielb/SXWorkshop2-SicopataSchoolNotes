using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SicopataSchool.NotesManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SicopataSchoolDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SicopataSchoolConnectionString")));
        }
    }
}
