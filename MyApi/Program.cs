using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyApi.BL;
using MyApi.DA.EF;
using MyApi.Transversal.Entidades;
var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection("CustomSettings").Get<CustomSettings>();
var connection = builder.Configuration.GetConnectionString("SuSaludCore");

settings.SuSaludConnection = connection;
builder.Services.AddDbContext<MyApiContext>(options =>
{
   // options.UseSqlServer(connection)
#if DEBUG
  //  .LogTo(Console.WriteLine);
#endif
});

builder.Services.AddControllers();

builder.Services.AddSingleton(settings);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = settings.JwtIssuer,
            ValidAudience = settings.JwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtKey))
        };
    });

builder.Services.AddLogicServices();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToFile("index.html");
    endpoints.MapControllers();
});
app.Run();
