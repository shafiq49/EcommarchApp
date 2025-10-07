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
app.MapGet("/api/categories", () =>
{
    return Results.Ok(Categories);
});

app.MapPost("/api/categories", () =>
{
    var newCategory = new Category
    {
       CategoryId = Guid.Parse("aa2c90bf-6ae7-4d78-a160-154ac35e9843"),
       Name = "Electronics",
       Description = "Electronics devices",
       CreatedAt = DateTime.UtcNow,
    };
    Categories.Add(newCategory);
    return Results.Created($"/api/categories/{newCategory.CategoryId}",newCategory);
});

app.MapDelete("/api/categories", () =>
{
    var foundCategory = Categories.FirstOrDefault(Category => Category.CategoryId == Guid.Parse("aa2c90bf-6ae7-4d78-a160-154ac35e9843"));
    if (foundCategory == null)
    {
        return Results.NotFound("Category Not Found");
    }
    Categories.Remove(foundCategory);
    return Results.NoContent();
});

app.MapPut("/api/categories", () =>
{
    var foundCategory = Categories.FirstOrDefault(Category => Category.CategoryId == Guid.Parse("aa2c90bf-6ae7-4d78-a160-154ac35e9843"));
    if (foundCategory == null)
    {
        return Results.NotFound("Category Not Found");
    }
    foundCategory.Name = "Shafiq";
    foundCategory.Description = "Shafiq is a name";   
    return Results.NoContent();
});

//app.MapGet("/", () => "API testing perfectly");

//app.MapGet("/hello",() =>
//{
//    var resposne = new { message = "Get Successfull message", success = true };
//    return Results.Ok(resposne);
//});
//app.MapPost("/hello", () => 
//{
//    return Results.Created();
//});
//app.MapPut("/hello", () =>
//{
//    return Results.NoContent();
//});
//app.MapDelete("/hello", () =>
//{
//    return Results.NoContent();
//});

app.MapControllers();

app.Run();

public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }  
  
};
