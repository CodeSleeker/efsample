using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    public static class Services
    {
        public static ServiceProvider serviceProvider = new ServiceCollection()
            .AddDbContext<DataDBContext>(options =>
            {
                options.UseSqlite($@"Data Source = {App.DB}");
            })
            .AddScoped<IPerson>(provider => new StorePerson(provider.GetService<DataDBContext>()))
            .BuildServiceProvider();
        public static IPerson PersonStore = serviceProvider.GetService<IPerson>();
    }
}
