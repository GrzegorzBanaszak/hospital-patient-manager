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
sqlConnectionBuilder.UserID = Environment.GetEnvironmentVariable("USER_ID");
sqlConnectionBuilder.Password = Environment.GetEnvironmentVariable("PASSWORD");


//Add dependence
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(sqlConnectionBuilder.ConnectionString));
builder.Services.AddScoped<IPatientRepo, PatientRepo>();
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
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

app.MapGet("api/patient/{id}", async (IPatientRepo repo, IMapper mapper, int id) =>
{
    var patientModel = await repo.GetById(id);

    if (patientModel == null) return Results.NotFound();

    return Results.Ok(mapper.Map<PatientReadDto>(patientModel));

});

app.MapPost("api/patient/", async (IPatientRepo repo, IMapper mapper, PatientCreateDto dto) =>
{
    var patientModel = mapper.Map<Patient>(dto);

    await repo.Create(patientModel);
    await repo.SaveChanges();

    var patientRead = mapper.Map<PatientReadDto>(patientModel);

    return Results.Created($"api/v1/commands/{patientModel.Id}", patientRead);

});

app.MapPut("api/patient/{id}", async (IPatientRepo repo, IMapper mapper, int id, PatientUpdateDto dto) =>
{
    var patientModel = await repo.GetById(id);

    if (patientModel == null) return Results.NotFound();

    mapper.Map(dto, patientModel);

    await repo.SaveChanges();

    return Results.NoContent();


});

app.MapDelete("api/patient/{id}", async (IPatientRepo repo, IMapper mapper, int id) =>
{
    var patientModel = await repo.GetById(id);

    if (patientModel == null)
    {
        return Results.NotFound();
    }

    repo.Delete(patientModel);

    await repo.SaveChanges();

    return Results.NoContent();

});

#endregion

#region Doctor

app.MapGet("api/doctor/", async (IDoctorRepo repo, IMapper mapper) =>
{
    var doctors = await repo.GetAll();

    return Results.Ok(mapper.Map<DoctorReadDto>(doctors));
});

app.MapGet("api/doctor/{id}", async (IDoctorRepo repo, IMapper mapper, int id) =>
{
    var doctor = await repo.GetById(id);

    if (doctor != null) return Results.Ok(mapper.Map<DoctorReadDto>(doctor));

    return Results.NotFound();
});

app.MapPost("api/doctor", async (IDoctorRepo repo, IMapper mapper, DoctorCreateDto dto) =>
{
    var doctor = mapper.Map<Doctor>(dto);

    await repo.Create(doctor);
    await repo.SaveChanges();

    var readPatient = mapper.Map<DoctorReadDto>(doctor);

    return Results.Created($"api/doctor/{readPatient.Id}", readPatient);

});

app.MapPut("api/doctor/{id}", async (IDoctorRepo repo, IMapper mapper, DoctorUpdateDto dto, int id) =>
{
    var doctorModel = await repo.GetById(id);

    if (doctorModel == null) return Results.NotFound();

    mapper.Map(dto, doctorModel);

    await repo.SaveChanges();

    return Results.NoContent();

});

#endregion


app.Run();
