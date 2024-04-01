var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

List<Car> cars =
    [
        new Car()
        {
            Name = "Camry",
            Model = 2017,
            Color = "White"
        },
        new Car()
        {
            Name ="Rav4",
            Model= 2020,
            Color="red"

        }

        ];
app.MapGet("/", () => "This is Car API");
app.MapGet("/greeting", () => "Welcome to Car API");
app.MapGet("/Car/{name}", (string name) => $"This is {name} ");
app.MapGet("/Car/{name}/{model:int}", (string name, int model, string? color)
    => $"This is {name}, and the model is {model} and the color is {color}");
app.MapGet("/{name}/{model}", (string name, int model, string? color)
    => new Car
{
Name = name,
Model = model,
Color = color
});
app.MapGet("/cars", () => cars);



app.Run();

class Car
{
    public string Name { get; set; }
    public int Model { get; set; }
    public string? Color { get; set; }
    public string FullInfo => Color is not null ? $"{Color} {Name}" : Name;
}
