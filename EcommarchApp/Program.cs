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

List<Category> Categories = new List<Category>();

//Get  categorite 
app.MapGet("/api/category", () =>
{
    return Results.Ok(Categories);
});

app.MapGet("/", () => "API testing perfectly");

app.MapGet("/hello",() =>
{
    var resposne = new { message = "Get Successfull message", success = true };
    return Results.Ok(resposne);
});
app.MapPost("/hello", () => 
{
    return Results.Created();
});
app.MapPut("/hello", () =>
{
    return Results.NoContent();
});
app.MapDelete("/hello", () =>
{
    return Results.NoContent();
});

app.MapControllers();

app.Run();

public record Category
{
    public Guid ProductId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }  
  
};
