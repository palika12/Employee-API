using Employee_core.Data;
using Employee_core.EmployeeService;
using Employee_core.IEmployeeRepository;
using Employee_core.IEmployeeService;
using Microsoft.EntityFrameworkCore;

namespace Employee_API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmpRepository, EmployeeRepository>();
            services.AddScoped<IEmpService, EmployeeService>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddDbContext<EmployeeDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
