using RentHouse.DataAccess.Interface.Admins;
using RentHouse.DataAccess.Interface.Apartments;
using RentHouse.DataAccess.Interface.Users;
using RentHouse.DataAccess.Repository.admins;
using RentHouse.DataAccess.Repository.Apartments;
using RentHouse.DataAccess.Repository.Users;
using RentHouse.Service.Intesfaces.Admins;
using RentHouse.Service.Intesfaces.Apartments;
using RentHouse.Service.Intesfaces.Auth;
using RentHouse.Service.Intesfaces.Commons;
using RentHouse.Service.Intesfaces.Notifications;
using RentHouse.Service.Intesfaces.Users;
using RentHouse.Service.Services.Admins;
using RentHouse.Service.Services.Apartments;
using RentHouse.Service.Services.Auth;
using RentHouse.Service.Services.Commons;
using RentHouse.Service.Services.Notifications;
using RentHouse.Service.Services.Users;
using RentHouse.WebApi.Configurations;
using RentHouse.WebApi.Configurations.Layer;
//using RentHouse.Service.Services.Apartments;
//using RentHouse.Service.Services.Commons;

internal class Program
{
    private static void Main(string[] args)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // Add services to the container.
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddMemoryCache();
        builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IApartmentRepository, ApartmentRepositorys>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IEmailSender, SmsSender>();
        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<IFIleService, FileService>();
        builder.Services.AddScoped<IApartmentService, ApartmentService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.ConfigureJwtAuth();
        builder.ConfigureDataAccess();
        builder.ConfigureServiceLayer();
        builder.ConfigureSwaggerAuth();
        var app = builder.Build();

        // Configure the HTTP request pipeline.



        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseStaticFiles();

        //app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}