using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using myorange_pmproject.Data;
 
using System.Configuration;
using myorange_pmproject.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<MyOrangePMPProjectContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Myorange_PMProjectContext_sqlite") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<ProjectService>();
builder.Services.AddHttpClient();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)

    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/LoginUser";
        options.LoginPath = "/LoginUser";
    });
/*
    .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true, //是否验证Issuer
                ValidIssuer = builder.Configuration["Jwt:Issuer"], //发行人Issuer
                ValidateAudience = true, //是否验证Audience
                ValidAudience = builder.Configuration["Jwt:Audience"], //订阅人Audience
                ValidateIssuerSigningKey = true, //是否验证SecurityKey
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])), //SecurityKey
                ValidateLifetime = true, //是否验证失效时间
                ClockSkew = TimeSpan.FromSeconds(30), //过期时间容错值，解决服务器端时间不同步问题（秒）
                RequireExpirationTime = true,
            };
        }
     );

*/


// 添加日志提供者  
builder.Logging.ClearProviders(); // 如果需要的话，先清除默认提供者  
//builder.Logging.AddFilter("Microsoft", LogLevel.Warning); // 设置Microsoft日志的级别  
//builder.Logging.AddFilter("System", LogLevel.Warning);  
builder.Logging.AddFilter("myorange_pmproject", LogLevel.Information); // 设置你的命名空间或类的日志级别  
  
// 添加控制台日志提供者  
builder.Logging.AddConsole();  

var app = builder.Build();


//使用验证
app.UseAuthentication();
app.UseAuthorization();
//app.UseAuthentication();//身分驗證

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

////var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
//using (var scope = scopeFactory.CreateScope())
////{
    ///var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    //if (db.Database.EnsureCreated())
    ////{
     //   SeedData.Initialize(db);
   // }
//}

app.Run();
