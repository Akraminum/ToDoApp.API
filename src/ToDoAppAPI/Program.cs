
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using ToDoAppAPI.DataBase;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Services;
using ToDoAppAPI.Services.IServices;
using ToDoAppAPI.Utitlities.Auth;
using ToDoAppAPI.Utitlities.Responses;

var appBuilder = WebApplication.CreateBuilder(args);

#region SERVICES

appBuilder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Hour)
	);

#region Init
// Add services to the container.
appBuilder.Services.AddControllers();

appBuilder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(appBuilder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region AddIdentity
appBuilder.Services
    .AddIdentityCore<UserEntity>(options => {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
#endregion

#region  AddAuthentication
appBuilder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,

            ValidAudience = appBuilder.Configuration["Jwt:Audience"],
            ValidIssuer = appBuilder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(appBuilder.Configuration["Jwt:Key"]!)
            )
        };
    });
#endregion

#region AddAuthorization
appBuilder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        Policies.AdministrativePolicy, 
        policy => policy.RequireRole(Roles.SuperAdmin, Roles.Admin));
});
#endregion


appBuilder.Services.AddScoped<ITokenCreationService, JwtService>();

appBuilder.Services.AddAutoMapper(typeof(Program));

appBuilder.Services.AddSwaggerGen();

#endregion

var app = appBuilder.Build();

#region Pipeline
#region Swagger
app.UseSwagger();
app.UseSwaggerUI();
#endregion

// Configure the HTTP request pipeline.   
app.UseHttpsRedirection();


// CARE for all Unhandled exceptions
app.UseResponseWrapper();
app.UseMiddleware<ConsistentApiResponseErrors.Middlewares.ExceptionHandlerMiddleware>();

    
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); 


#endregion

app.Run();

