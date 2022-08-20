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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XCafeProject.Data;
using XCafeProject.Email;

namespace XCafeProject
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

            //toastr.js'i kullanabilmek i�in tanmlad�k
            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions
            {
                //kapat butonu ekler
                CloseButton=true,
                //mesaj�n yeri
                PositionClass=ToastPositions.BottomRight,
                //tekrarlanan k�s�mlar� kapat�r
                PreventDuplicates=true
            });

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<IdentityUser,IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //email do�rulama ve �ifre s�f�rlama servisini a�t�k
            services.AddSingleton<IEmailSender, EmailSender>();

            //sendGrid servisi aktile�tirildi
            services.Configure<EmailOptions>(Configuration);

            //AddRazorRuntimeCompilation=> front-end taraf�nda yapt���m�z de�i�iklikleri an�nda taray�c� �zerinde g�rmemizi sa�lar
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddRazorPages();

            //yetkisiz bir �ekilde sayfaya gitmek istedi�inde belirlemi� oldu�umuz sayfaya y�nlendirme i�lemi yapt�rmak i�in tan�mland�
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });
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
