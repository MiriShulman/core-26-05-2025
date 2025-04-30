using OurApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddBooksConst();
// builder.Services.AddUsersJson();
builder.Services.AddScoped<TokenService>();
builder.Services.AddGenericConst();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// services.AddScoped<TokenService>();

app.UseAuthorization();

app.MapControllers();

app.Run();
