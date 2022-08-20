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

                //mesaj�n konumu
                PositionClass=ToastPositions.TopRight,

                //tekrarlanan yap�lar�n tekrarlanmamas� sa�lan�r
                PreventDuplicates=true
            });

            services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton<IEmailSender, EmailSender>();

            /* sendgrid i�lemi i�in tan�mland�(e mail do�rulama */

            services.Configure<EmailOptions>(Configuration);

            /* sendgrid i�lemi i�in tan�mland�(e mail do�rulama bitti */

            //AddRazorRuntimeCompilation=> front-end k�sm�nda olan de�i�iklikleri an�nda g�r�p de�i�iklikleri tarayarak veritaban�na aktar�m� sa�lar
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddRazorPages();

            /* Yetkisiz kullan�c�lar�n ilgili sayfalara t�kland���nda belirlenene sayfaya y�nlendirme ayar� */

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
            
            /* Yetkisiz kullan�c�lar�n ilgili sayfalara t�kland���nda belirlenene sayfaya y�nlendirme ayar� bitti */

            /* facebook ile giri� i�in gerekli ayar */

            services.AddAuthentication().AddFacebook(options =>
            {
                options.AppId = "760046255312031";
                options.AppSecret = "f3832af46ff935e17842b379ded346eb";
            });

            /* facebook ile giri� i�in gerekli ayar  bitti */

            /* google ile giri� i�in gerekli ayar */

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "512473495672-3th48mab0vej5pmp29n1be2mh5e5u3a1.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });

            /* google ile giri� i�in gerekli ayar  bitti */

            /* session i�lemleri i�in tan�mland� */

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); //30 dakikal�k oturum a�ar
                options.Cookie.HttpOnly = true; //cookie'lere izin verir
                options.Cookie.IsEssential = true;
            });

            /* session i�lemleri i�in tan�mland� bitti */
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

            //session i�lemleri kullanabilmek i�in tan�mland�
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
