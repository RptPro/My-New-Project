using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.WindowsServices;

namespace DataBaseWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Uncomment if you need Swagger
            // builder.Services.AddSwaggerGen();

            // Enable Windows Service
            builder.Host.UseWindowsService();

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use the named CORS policy
            app.UseCors("AllowAll");

            // Enable HTTPS redirection in production
            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            // Enable Swagger if needed
            // app.UseSwagger();
            // app.UseSwaggerUI();

            // Run the application on the specified port
            app.Run("http://0.0.0.0:5001");
        }
    }
}

//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Hosting.WindowsServices;

//namespace DataBaseWebAPI
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Configure CORS policy
//            builder.Services.AddCors(options =>
//            {
//                options.AddPolicy("AllowAll", policy =>
//                {
//                    policy.AllowAnyOrigin()
//                          .AllowAnyMethod()
//                          .AllowAnyHeader();
//                });
//            });

//            // Add services to the container
//            builder.Services.AddControllers();
//            builder.Services.AddEndpointsApiExplorer();

//            // Enable OpenAPI/Swagger if needed
//            // builder.Services.AddSwaggerGen();

//            builder.Host.UseWindowsService(); // Enable Windows Service
//            CreateHostBuilder(args);

//            var app = builder.Build();

//            // Configure the HTTP request pipeline
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseCors("AllowAll");  // Use the named CORS policy

//            // HTTPS redirection (can be omitted if using HTTP for testing)
//            if (!app.Environment.IsDevelopment()) // Disable in local development for HTTP testing
//            {
//                app.UseHttpsRedirection();
//            }

//            app.UseRouting();
//            app.UseAuthorization();
//            app.MapControllers();

//            // Enable Swagger if needed
//            // app.UseSwagger();
//            // app.UseSwaggerUI();

//            // Run the application
//            app.Run("http://0.0.0.0:5001");
//        }
//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//    Host.CreateDefaultBuilder(args)
//        .ConfigureWebHostDefaults(webBuilder =>
//        {
//            webBuilder.UseStartup<Program>();
//            webBuilder.UseUrls("http://0.0.0.0:5001");  // או ה-Port שאתה רוצה
//        });
//    }
//}

////using Microsoft.AspNetCore.Builder;
////using Microsoft.AspNetCore.Hosting;
////using Microsoft.Extensions.DependencyInjection;
////using Microsoft.Extensions.Hosting;
////using Microsoft.Extensions.Hosting.WindowsServices;
////namespace DataBaseWebAPI
////{
////    public class Program
////    {
////        public static void Main(string[] args)
////        {
////            var builder = WebApplication.CreateBuilder(args);

////            builder.Services.AddCors(options =>
////            {
////                options.AddPolicy("AllowAll", policy =>
////                {
////                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
////                });
////            });
////            // Add services to the container.

////            builder.Services.AddControllers();
////            builder.Services.AddEndpointsApiExplorer();
////            builder.Host.UseWindowsService();
////            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
////            //builder.Services.AddOpenApi();

////            var app = builder.Build();

////            // Configure the HTTP request pipeline.
////            if (app.Environment.IsDevelopment())
////            {
////                app.UseDeveloperExceptionPage();
////            }
////            app.UseCors("AllowAll");
////            app.UseHttpsRedirection();
////            app.UseRouting();

////            app.UseAuthorization();


////            app.MapControllers();

////            app.Run();
////        }
////    //    public static IHostBuilder CreateHostBuilder(string[] args) =>
////    //Host.CreateDefaultBuilder(args)
////    //    .ConfigureWebHostDefaults(webBuilder =>
////    //    {
////    //        webBuilder.UseStartup<StartupBase>();

////    //    }).ConfigureWebHost(config =>
////    //    {
////    //        config.UseUrls("http://*:7216");

////    //    }).UseWindowsService();
////    }
////}
