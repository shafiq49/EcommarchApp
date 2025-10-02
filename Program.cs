var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.MapGet("/", ()=>{
    return "API testing well";
});

app.MapGet("/get", ()=>{
    return "Hello SaFaN";
});

app.MapPost("/post", () =>
{
    return "Post Method";
});

app.Run();

