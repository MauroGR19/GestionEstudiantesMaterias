using Aplication.Interface;
using Aplication.UseCase;
using AutoMapper;
using Data.Contex;
using Data.Operation;
using Domain.Interface.Repository;
using Domain.Model;
using GestionEstudiantesMaterias.Interface;
using GestionEstudiantesMaterias.Models;
using GestionEstudiantesMaterias.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region "Inyeccion de dependencias"

//DB connection
var connectionString = builder.Configuration.GetConnectionString("GestionEstudiantesMaterias");
builder.Services.AddDbContext<StudentSubjectContex>(x =>
{
    x.UseSqlServer(connectionString);
    x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//Repository
builder.Services.AddTransient<IRepoBase<StudentModel, string>, StudentOpe>();
builder.Services.AddTransient<IRepoBase<SubjectModel, int>, SubjectOpe>();
builder.Services.AddTransient<IEnrollmentRepo<EnrollmentModel, int>, EnrollmentOpe>();

//UseCases
builder.Services.AddTransient<IUseCaseBase<StudentModel, string>, StudentUseCase>();
builder.Services.AddTransient<IUseCaseBase<SubjectModel, int>, SubjectUseCase>();
builder.Services.AddTransient<IUseCaseEnrollment<EnrollmentModel, int>, EnrollmentUseCase>();

//Services
builder.Services.AddTransient<IBaseService<StudentDto, string>, ClsStudentServ>();
builder.Services.AddTransient<IBaseService<SubjectDto, int>, ClsSubjectServ>();
builder.Services.AddTransient<IEnrollmentService<EnrollmentDto, int>, ClsEnrollmentServ>();

#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{ 
    StudentSubjectContex contex = scope.ServiceProvider.GetRequiredService<StudentSubjectContex>();
    contex.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
