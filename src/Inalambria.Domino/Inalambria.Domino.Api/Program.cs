using Inalambria.Domino.Core.Authentication;
using Inalambria.Domino.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


var configuration = builder.Configuration;


//DBContext

builder.Services.AddDbContext<DominoDbContext>(options =>
                                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
//options.UseInMemoryDatabase(databaseName: "test"));


builder.Services.AddIdentity<User, Role>(
    opts =>
    {
        opts.Password.RequireDigit = true;
        opts.Password.RequireLowercase = true;
        opts.Password.RequireUppercase = true;
        opts.Password.RequireNonAlphanumeric = true;
        opts.Password.RequiredLength = 7;
        opts.Password.RequiredUniqueChars = 4;
    })
    .AddEntityFrameworkStores<DominoDbContext>()
    .AddDefaultTokenProviders();



builder.Services.Configure<JwtTokenValidationSettings>(builder.Configuration.GetSection("JwtTokenValidationSettings"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    //Swagger Add JWT Authoritation
    option.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token in the text input below.\r\n",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id=JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[]{}
        }
    });
});

var tokenValidationSettings = builder.Services.BuildServiceProvider().GetService<IOptions<JwtTokenValidationSettings>>().Value;


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = tokenValidationSettings.ValidIssuer,
            ValidAudience = tokenValidationSettings.ValidAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenValidationSettings.SecretKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddSingleton<IConfiguration>(configuration);


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

app.Run();
