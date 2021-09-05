using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Less1Ex1
{
    /*
        Долгуев Владимир.
        Написать свой контроллер и методы в нем, которые бы предоставляли следующую функциональность:
        - Возможность сохранить температуру в указанное время
        - Возможность прочитать список показателей температуры за указанный промежуток времени
        - Возможность отредактировать показатель температуры в указанное время
        - Возможность удалить показатель температуры в указанный промежуток времени
     */

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}