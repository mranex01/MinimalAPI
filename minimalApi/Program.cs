using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using minimalApi.Data;
using minimalApi.Data.Model;
using minimalApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Appdb"))
 );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//async Task<List<Student>> GetStudent(AppDbContext context)=> await context.Students.ToListAsync();

//app.MapPost("Student", async (AppDbContext context , Student item)=>
//{
//    context.Students.Add(item);
//    await context.SaveChangesAsync();
//    return Results.Ok(await GetStudent(context));
//});

//app.MapGet("Student", async (AppDbContext context) => await context.Students.ToListAsync());

//app.MapGet("Student/{id}", async (AppDbContext context, int id) =>
//{
//    var data = await context.Students.FindAsync(id);
//    if (data == null)
//    {
//        return Results.NotFound();
//    }
//    else
//    return Results.Ok(data);
//});

//app.MapPut("Student/{id}", async (AppDbContext context, Student item, int id) =>
//{
//    var studentItem = await context.Students.FindAsync(id);
//    if(studentItem== null)
//    {
//        return Results.NotFound();
//    }
//    studentItem.studentName = item.studentName;
//    studentItem.studentClass = item.studentClass;
//    context.Students.Update(studentItem);
//    await context.SaveChangesAsync();
//    return Results.Ok(studentItem);
//});

//app.MapDelete("Student/{id}", async (AppDbContext context, int id) =>
//{
//    var data = await context.Students.FindAsync(id);
//    if (data == null)
//    {
//        return Results.NotFound();
//    }

//    context.Students.Remove(data);
//    await context.SaveChangesAsync();
//    return Results.Ok(data);
//});



app.UseHttpsRedirection();
app.MapStudentEndpoints();

app.Run();
