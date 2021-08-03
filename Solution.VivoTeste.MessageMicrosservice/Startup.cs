using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Solution.VivoTeste.MessageMicrosservice.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Solution.VivoTeste.MessageMicrosservice.Dominio.Ports;
using Solution.VivoTeste.MessageMicrosservice.Infraestrutura.Repositorio;
using Solution.VivoTeste.MessageMicrosservice.Aplicacao.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Solution.VivoTeste.MessageMicrosservice
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

            //services.AddDbContext<BotContext>(opt =>
            //                                   opt.UseInMemoryDatabase("BancoDados"));

            services.AddDbContext<MessageContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IServicoMensagem, MessageService>();
            services.AddScoped<IMessageConsultaRepositorio, MessageRepository>();
            services.AddScoped<IMessagecomandoRepositorio, MessageRepository>();


            services.AddControllers()
                    .AddJsonOptions(options =>
                       options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(x => x.FullName);
            });

            services.AddMvcCore(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
               });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseAuthentication();
            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
