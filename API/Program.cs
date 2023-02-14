using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionBuilder = new SqlConnectionStringBuilder();

//Create connection string from secret and json configuration
sqlConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("SQLDbConnection");
sqlConnectionBuilder.UserID = builder.Configuration["UserId"];
sqlConnectionBuilder.Password = builder.Configuration["Password"];



//Add dependence
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionBuilder.ConnectionString));
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Patient

app.MapGet("api/patient/", async (IPatientRepo repo, IMapper mapper) =>
{
    var patients = await repo.GetAll();

    return Results.Ok(mapper.Map<IEnumerable<PatientReadDto>>(patients));

});

app.MapPost("api/patient/add", async (IPatientRepo repo,IMapper mapper,PatientCreateDto dto) => { 
    var patientModel = mapper.Map<Patient>(dto);

    await repo.Create(patientModel);
    await repo.SaveChanges();

    var patientRead = mapper.Map<PatientReadDto>(patientModel);

    return Results.Created($"api/v1/commands/{patientModel.Id}", patientRead);

});

#endregion


app.Run();
