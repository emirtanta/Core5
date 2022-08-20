using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;
using OrnekSite.Data;
using OrnekSite.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrnekSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            //toastr aktif edildi
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions
            {
                //kapat butonu
                CloseButton=true,

                //mesajýn konumu
                PositionClass=ToastPositions.TopRight,

                //tekrarlanan yapýlarýn tekrarlanmamasý saðlanýr
                PreventDuplicates=true
            });

            services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton<IEmailSender, EmailSender>();

            /* sendgrid iþlemi için tanýmlandý(e mail doðrulama */

            services.Configure<EmailOptions>(Configuration);

            /* sendgrid iþlemi için tanýmlandý(e mail doðrulama bitti */

            //AddRazorRuntimeCompilation=> front-end kýsmýnda olan deðiþiklikleri anýnda görüp deðiþiklikleri tarayarak veritabanýna aktarýmý saðlar
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddRazorPages();

            /* Yetkisiz kullanýcýlarýn ilgili sayfalara týklandýðýnda belirlenene sayfaya yönlendirme ayarý */

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            
            /* Yetkisiz kullanýcýlarýn ilgili sayfalara týklandýðýnda belirlenene sayfaya yönlendirme ayarý bitti */

            /* facebook ile giriþ için gerekli ayar */

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "760046255312031";
                options.AppSecret = "f3832af46ff935e17842b379ded346eb";
            });

            /* facebook ile giriþ için gerekli ayar  bitti */

            /* google ile giriþ için gerekli ayar */

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "512473495672-3th48mab0vej5pmp29n1be2mh5e5u3a1.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });

            /* google ile giriþ için gerekli ayar  bitti */

            /* session iþlemleri için tanýmlandý */

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); //30 dakikalýk oturum açar
                options.Cookie.HttpOnly = true; //cookie'lere izin verir
                options.Cookie.IsEssential = true;
            });

            /* session iþlemleri için tanýmlandý bitti */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //session iþlemleri kullanabilmek için tanýmlandý
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
