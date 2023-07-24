using RentHouse.DataAccess.Interface.Apartments;
using RentHouse.DataAccess.Repository.Apartments;
using RentHouse.Service.Intesfaces.Apartments;
using RentHouse.Service.Intesfaces.Commons;
using RentHouse.Service.Services.Apartments;
using RentHouse.Service.Services.Commons;
//using RentHouse.Service.Services.Apartments;
//using RentHouse.Service.Services.Commons;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IFIleService, FileService>();
        builder.Services.AddScoped<IApartmentRepository, ApartmentRepositorys>();
        //builder.Services.AddScoped<IApartmentService, ApartmentService>();
        builder.Services.AddScoped<IApartmentService, ApartmentService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.



        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}