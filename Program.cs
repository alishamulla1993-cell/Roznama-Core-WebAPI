using Roznama.Common.Extensions;
using Roznama.Common.Helpers;
using Roznama.Infrastructure.Database;
using Roznama.Models.Litigation;
using Roznama.Modules.Auth;
using Roznama.Modules.Common;
using Roznama.Models.Dashboard;
using Roznama.Modules.Notice;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------------------
// Controllers
// --------------------------------------------------------
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.DictionaryKeyPolicy = null;
    });

// --------------------------------------------------------
// ✅ CORS HARD-CODED (TO CONFIRM IT WORKS)
// --------------------------------------------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AppCors", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",
                "http://localhost:3000"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// --------------------------------------------------------
// AppSettings (keep this)
// --------------------------------------------------------
builder.Services.Configure<Roznama.Config.AppSettings>(builder.Configuration);

// --------------------------------------------------------
// Core services
// --------------------------------------------------------
builder.Services.AddSingleton<TokenHelper>();
builder.Services.AddSingleton<DapperHelper>();
builder.Services.AddSingleton<DbConnectionFactory>();

// --------------------------------------------------------
// Modules
// --------------------------------------------------------
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AuthRepository>();

builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<DashboardRepository>();

builder.Services.AddScoped<NoticeService>();
builder.Services.AddScoped<NoticeRepository>();

builder.Services.AddScoped<DropdownService>();
builder.Services.AddScoped<DropdownRepository>();

builder.Services.AddScoped<LitigationService>();
builder.Services.AddScoped<LitigationRepository>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

// --------------------------------------------------------
// JWT (keep this)
// --------------------------------------------------------
builder.Services.AddJwtAuthentication(builder.Configuration);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

// ✅ CORS MUST BE HERE
app.UseCors("AppCors");

// ✅ Allow OPTIONS globally
//app.Use(async (context, next) =>
//{
//    if (context.Request.Method == "OPTIONS")
//    {
//        context.Response.StatusCode = 200;
//        await context.Response.CompleteAsync();
//        return;
//    }
//    await next();
//});
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();
app.Run();