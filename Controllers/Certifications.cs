using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EntityFrameworkCore.Jet;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
namespace somecontrollers.Controllers;

public static class StudentEndpoints
{
    
    public static async void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Student").WithTags(nameof(Student));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new ModelContext())
            {
                return context.Students.ToList();
            }

        })
        .WithName("GetAllStudents")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new ModelContext())
            {
                return context.Students.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetStudentById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Student input) =>
        {
            using (var context = new ModelContext())
            {
                Student[] somestudent = context.Students.Where(m => m.Id == id).ToArray();
                context.Students.Attach(somestudent[0]);
                //somestudents[0] = input;
                //Student result = new Student();
                //somestudent[0].Id = input.Id;
                somestudent[0].LastName = input.LastName;
                somestudent[0].FirstName = input.FirstName;
                somestudent[0].EMailAddress = input.EMailAddress;
                //context.Entry(somestudent[0]).State = EntityState.Modified;
                //result.LastName = "Smith";
                //result.FirstName = "Kyle";
                context.SaveChanges();
                //await context.SaveChangesAsync();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateStudent")
        .WithOpenApi();

        group.MapPost("/", async (Student input) =>
        {
            using (var context = new ModelContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                input.Id = dice;
                context.Students.Add(input);
                await context.SaveChangesAsync();                     
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateStudent")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            using (var context = new ModelContext())
            {
                //context.Students.Add(std);
                Student[] somestudents = context.Students.Where(m => m.Id == id).ToArray();
                context.Students.Attach(somestudents[0]);
                context.Students.Remove(somestudents[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteStudent")
        .WithOpenApi();
    }
}

   