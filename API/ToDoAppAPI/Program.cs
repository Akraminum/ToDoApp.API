
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoAppAPI.DataBase;
using ToDoAppAPI.Entities;
using ToDoAppAPI.Services;
using ToDoAppAPI.Services.IServices;

var appBuilder = WebApplication.CreateBuilder(args);

// Add services to the container.
appBuilder.Services.AddControllers();

appBuilder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(appBuilder.Configuration.GetConnectionString("DefaultConnection"));
});

appBuilder.Services
    .AddIdentityCore<UserEntity>(options => {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 3;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();



appBuilder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = appBuilder.Configuration["Jwt:Audience"],
            ValidIssuer = appBuilder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(appBuilder.Configuration["Jwt:Key"]!)
            )
        };
    });


appBuilder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy",
        policy => policy.RequireAssertion(ctx => 
            (ctx.User.IsInRole("Admin") || ctx.User.IsInRole("SuperAdmin")) ));
});




appBuilder.Services.AddScoped<ITokenCreationService, JwtService>();

appBuilder.Services.AddAutoMapper(typeof(Program));

appBuilder.Services.AddSwaggerGen();
var app = appBuilder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
