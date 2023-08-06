using ChatGpt.Interfaces;
using ChatGpt.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<OpenAIService>();
builder.Services.AddScoped<IOpenAIService, OpenAIService>();

//برای کراس اورجین
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});

var app = builder.Build();
var isStaging = builder.Configuration.GetValue<bool>("IsStaging");
// Configure the HTTP request pipeline.
if(isStaging)// (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//برای کراس اورجین
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
