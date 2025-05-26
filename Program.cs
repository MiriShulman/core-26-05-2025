using OurApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens; // הוספת המרחב השמות עבור TokenValidationParameters
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using OurApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    { new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
            },
        new string[] {}
    }
    });
});

builder.Services.Configure<JWTSettings>
(builder.Configuration.GetSection("JWTSettings"));
// public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
// {
//     app.UseRouting();

//     app.UseEndpoints(endpoints =>
//     {
//         endpoints.MapControllers();
//     });
// }


var jwtSettings = builder.Configuration.GetSection("JWTSettings").Get<JWTSettings>();


// הגדרת מנגנון האימות
// הגדרת שירותי האותנטיקציה
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // או בהתאם לצורך
    })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        // הגדר את הערכים הבאים בהתאם לצרכים שלך
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hs57sn7sv8a3bb7cbh2x"))

    };
});

// הגדרת מדיניות ההרשאה "Admin"
// builder.Services.AddAuthorization(cfg =>
// {
//     cfg.AddPolicy("Admin", 
//                         policy => policy.RequireClaim("type", "Admin"));
// });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
        policy.RequireClaim("type","Admin")); // או כל דרישה אחרת שתרצי
});


builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<LoginService>();

builder.Services.AddGenericConst();

var app = builder.Build();
app.UseRouting();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        c.RoutePrefix = string.Empty; // אם אתה רוצה שה-Swagger UI יהיה בדף הבית
    });
}


        // }


app.UseHttpsRedirection();

app.UseAuthorization();

// הפעלת Middleware לאותנטיקציה
app.UseAuthentication();

app.MapControllers();


app.Run();
