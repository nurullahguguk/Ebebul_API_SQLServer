using Ebebul.API.Filters;
using Ebebul.API.Middlewares;
using Ebebul.Core.Repositories;
using Ebebul.Core.Services;
using Ebebul.Core.UnitofWorks;
using Ebebul.Repository;
using Ebebul.Repository.Repositories;
using Ebebul.Repository.UnitofWorks;
using Ebebul.Service.Mapping;
using Ebebul.Service.Services;
using Ebebul.Service.Validations;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => 
x.RegisterValidatorsFromAssemblyContaining<UserDtoValidator>());

//Kendi filterimizi frameforkun filterini baskıladık.
builder.Services.Configure<ApiBehaviorOptions>(options=> options.SuppressModelStateInvalidFilter =true);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection"), option =>
    {
        //option.MigrationsAssembly("NLayer/Repository");
        //Üstteki gibi yazmak yerine dinamik þekilde vermek için Assembly kullandýk. Böylece Repository ismi deðiþse de bulabilmesi için.
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
