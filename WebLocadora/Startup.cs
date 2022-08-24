using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebLocadora.Areas.Admin.Servicos;
using WebLocadora.Context;
using WebLocadora.Models;
using WebLocadora.Repository;
using WebLocadora.Repository.Interface;
using WebLocadora.Services;

namespace WebLocadora
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

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<AppDbContext>()
             .AddDefaultTokenProviders();

            services.AddTransient<IFilmeCategoria, FilmeCategoriaRepository>();
            services.AddTransient<Ifilme, FilmeRepository>();
            services.AddTransient<IPedido, PedidoRepository>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp=>AlugarFilme.GetFilme(sp));
            services.AddScoped<RelatorioVendasService>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    politica =>
                    {
                        politica.RequireRole("Admin");
                    });
            });

            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            ,ISeedUserRoleInitial seedUserRoleInitial)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
            //cria os perfis
            seedUserRoleInitial.SeedRoles();
            //cria os usuários e atribui ao perfil
            seedUserRoleInitial.SeedUsers();

            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
                  
                );
                endpoints.MapControllerRoute(
                    name: "filmeFiltro",
                    pattern: "Filme/{action}/{categoria?}",
                    defaults: new { Controller = "Filme", action = "List" });




                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

