using Microsoft.EntityFrameworkCore;
using DAL.Repository.UoW;
using DAL.Data;
using BL.Services;
using DAL.Repository;
using DAL.Repository.Interfaces;
using BL.Auxilary;
using BL.Services.Interfaces;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


       
        builder.Services.AddDbContext<AuthDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
        builder.Services.AddScoped<IJwtService, JwtService>();
        builder.Services.AddScoped<UserLoginService>();
        builder.Services.AddScoped<JwtService>();
        builder.Services.Configure<AuthSettings>(
            builder.Configuration.GetSection("AuthSettings"));
        builder.Services.AddAuth(builder.Configuration);


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

       

        app.UseHttpsRedirection();
        app.UseAuthentication(); //
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}