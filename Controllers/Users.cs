using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EntityFrameworkCore.Jet;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
namespace somecontrollers.Controllers;

public static class UserEndpoints
{
    
    public static async void MapUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Users").WithTags(nameof(User));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Users.ToList();
            }

        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Users.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetUsersById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Users input) =>
        {
            using (var context = new CeContext())
            {
                User[] someUser = context.Users.Where(m => m.Id == id).ToArray();
                context.Users.Attach(someUser[0]);
                someUser[0].LastName = input.LastName;
                someUser[0].FirstName = input.FirstName;
                someUser[0].EMailAddress = input.EMailAddress;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateUser")
        .WithOpenApi();

        group.MapPost("/", async (User input) =>
        {
            using (var context = new ModelContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                input.Id = dice;
                context.Users.Add(input);
                await context.SaveChangesAsync();                     
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateUser")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            using (var context = new ModelContext())
            {
                //context.Users.Add(std);
                User[] someUsers = context.Users.Where(m => m.Id == id).ToArray();
                context.Users.Attach(someUsers[0]);
                context.Users.Remove(someUsers[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteUser")
        .WithOpenApi();
    }
}

   