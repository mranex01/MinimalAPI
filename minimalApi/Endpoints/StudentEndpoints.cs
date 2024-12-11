using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using minimalApi.Data;
using minimalApi.Data.Model;

namespace minimalApi.Endpoints
{
    public static class StudentEndpoints
    {
        public static void MapStudentEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("Students", async (AppDbContext context, Student item) =>
            {
                context.Students.Add(item);
                await context.SaveChangesAsync();
                return Results.Ok(await context.Students.ToListAsync());
            });

            app.MapGet("Students", async (AppDbContext context) => await context.Students.ToListAsync());

            app.MapGet("Students/{id}", async (AppDbContext context, int id) =>
            {
                var data = await context.Students.FindAsync(id);
                if (data == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(data);
            });

            app.MapPut("Students/{id}", async (AppDbContext context, Student item, int id) =>
            {
                var studentItem = await context.Students.FindAsync(id);
                if (studentItem == null)
                {
                    return Results.NotFound();
                }
                studentItem.studentName = item.studentName;
                studentItem.studentClass = item.studentClass;
                context.Students.Update(studentItem);
                await context.SaveChangesAsync();
                return Results.Ok(studentItem);
            });

            app.MapDelete("Students/{id}", async (AppDbContext context, int id) =>
            {
                var data = await context.Students.FindAsync(id);
                if (data == null)
                {
                    return Results.NotFound();
                }

                context.Students.Remove(data);
                await context.SaveChangesAsync();
                return Results.Ok(data);
            });
        }
    }
}
