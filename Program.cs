var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//Holding TaskItem Objects 
var tasks = new List<TaskItem>();


// Adding my own endpoint 
app.MapGet("/kaleb", () =>
{
    return "Kaleb Mallory .NET arc begins";
});

// The end point that already existed
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

//Return all tasks
app.MapGet("/tasks", () =>
{
    return tasks;
});

//Add a task
app.MapPost("/tasks", (string title) =>
{
    var id = tasks.Count + 1;
    var task = new TaskItem(id, title);

    tasks.Add(task);

    return tasks;
});

//Delete a task
app.MapDelete("/tasks/{index}", (int index) =>
{
    if (index >= 0 && index < tasks.Count)
    {
        tasks.RemoveAt(index);
    }
});

//getting just one item 
app.MapGet("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);

    return task is not null ? Results.Ok(task) : Results.NotFound();
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
//Adding in the class that will hold our Tasks
record TaskItem(int Id, string Title);