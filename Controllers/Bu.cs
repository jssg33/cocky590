using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using Enterprise.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http;
namespace somecontrollers.Controllers;

public static class BuEndpoints
{
    
    public static async void MapBuEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Bu").WithTags(nameof(Bu));

        //[HttpGet]
        group.MapGet("/", () =>
        {
            using (var context = new CeContext())
            {
                return context.Bus.ToList();
            }

        })
        .WithName("GetAllBus")
        .WithOpenApi();

        //[HttpGet]
        group.MapGet("/{id}", (int id) =>
        {
            using (var context = new CeContext())
            {
                return context.Bus.Where(m => m.Id == id).ToList();
            }
        })
        .WithName("GetBuById")
        .WithOpenApi();

        //[HttpPut]
        group.MapPut("/{id}", (int id, Bu input) =>
        {
            using (var context = new CeContext())
            {
                Bu[] someBu = context.Bus.Where(m => m.Id == id).ToArray();
                context.Bus.Attach(someBu[0]);
                someBu[0].Buname = input.Buname;
                context.SaveChanges();
                return TypedResults.Accepted("Updated ID:" + input.Id);
            }


        })
        .WithName("UpdateBu")
        .WithOpenApi();

        group.MapPost("/", async (Bu input) =>
        {
            using (var context = new CeContext())
            {
                Random rnd = new Random();
                int dice = rnd.Next(1000, 10000000);
                input.Id = dice;
                context.Bus.Add(input);
                await context.SaveChangesAsync();                     
                return TypedResults.Created("Created ID:" + input.Id);
            }

        })
        .WithName("CreateBu")
        .WithOpenApi();

        group.MapDelete("/{id}", async (int id) =>
        {
            using (var context = new CeContext())
            {
                //context.Bus.Add(std);
                Bu[] someBus = context.Bus.Where(m => m.Id == id).ToArray();
                context.Bus.Attach(someBus[0]);
                context.Bus.Remove(someBus[0]);
                context.SaveChanges();
            }

        })
        .WithName("DeleteBu")
        .WithOpenApi();
    }
}

   