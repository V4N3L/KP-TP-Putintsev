using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyWebSite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //добавляем поддержку контроллеров и представлений (MVC)
            services.AddControllersWithViews()
                //выставляем совместимость с asp.net core последней версии
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }
          public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //!!!Порядок регистрации сервисов очень важен

            //В процессе разработки нам важно видеть подробную информацию об ошибках
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage(); 

            app.UseRouting(); //система маршрутизации

            //подключаем поддержку статичных файлов в приложении (css, js и т.п)
            app.UseStaticFiles();

            //регистрируем нужные нам маршруты (эндпоинты)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); //название - default, по умолчанию Home контроллер, представление - index, параметр id не обязателен (знак ?)
            });
        }
    }
}
