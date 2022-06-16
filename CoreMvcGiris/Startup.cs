using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreMvcGiris
{


    //Net Core kütüphanesi olabildigince minimum gereksinimlere göre yazildigi için sadece uygulama yasam döngüsünde kullanilacak olan yapilar sisteme startup dosyasinda tanitilir.


    //Startup dosyasi .Net Core uygulamasinin çaliştiği dosyadir. Burada uygulama ile ilgili tüm ayarlar yapilir. Örneğin uygulamanin API veya Razor Pages veya MVC olarak tanimlanmasini bu class üzerinde gerçekleştiririz. Bunun dişinda uygulama içerisinde kullanilacak olan tüm ayarlarda bu dosyadan yapilabilir. Uygulaminin Authorization (Yetkilendirme) ve Authentication (Kimlik Doğrulama) ayarlari, Database bağlanti ayarlari, Https sertifika kullanim ayarlari, Route ayarlari ve bir çok ayar buradan yönetilebilir.
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();


            app.UseEndpoints(endpoints =>
            {
                // www.test.com.tr => Domain
                // www.test.com.tr/Musteriler => Domain/Controller demek oluyor
                //www.test.com.tr/Musteriler/Index => Domain/Controller/Action

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}