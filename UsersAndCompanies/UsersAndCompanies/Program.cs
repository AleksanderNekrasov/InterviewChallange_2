using Microsoft.EntityFrameworkCore;
using UsersAndCompanies.Actions;
using UsersAndCompaniesApplications;
using UsersAndCompaniesApplications.Dtos;
using UsersAndCompaniesDataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;
var configs = builder.Configuration;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAuthorization();
services.AddScoped<ActionsWithUser>();
services.AddScoped<ActionsWithCompanies>();
services.AddDbContext<UsersAndCompaniesContext>(options =>
               options.UseSqlServer(configs.GetConnectionString("UsersAndCompaniesConnection")));
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Actions with Users
app.MapPost("User", (ActionsWithUser actions, UserDto dto) => actions.Post(dto));
app.MapGet("User", (ActionsWithUser actions, Guid id) => actions.Get(id));
app.MapGet("Users", (ActionsWithUser actions) => actions.GetAll());
app.MapDelete("User", (ActionsWithUser actions, Guid id) => actions.Delete(id));
app.MapPut("User", (ActionsWithUser actions, UserDto dto) => actions.Put(dto));

// Actions with Companies
app.MapPost("Company", (ActionsWithCompanies actions, CompanyDto dto) => actions.Post(dto));
app.MapGet("Company", (ActionsWithCompanies actions, Guid id) => actions.Get(id));
app.MapGet("Companies", (ActionsWithCompanies actions) => actions.GetAll());
app.MapDelete("Company", (ActionsWithCompanies actions, Guid id) => actions.Delete(id));
app.MapPut("Company", (ActionsWithCompanies actions, CompanyDto dto) => actions.Put(dto));

app.Run();
