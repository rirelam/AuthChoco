using System.Text;
using AuthChoco.Data;
using AuthChoco.Logics;
using AuthChoco.Resolvers;
using AuthChoco.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var tokenSettings = builder.Configuration
    .GetSection("TokenSettings").Get<TokenSettings>();
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = tokenSettings.Issuer,
        ValidateIssuer = true,
        ValidAudience = tokenSettings.Audience,
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key)),
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddGraphQLServer()
    .AddQueryType<QueryResolver>()
    .AddMutationType<MutationResolver>()
    .AddAuthorization();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("roles-policy", policy =>
    {
        policy.RequireRole(new string[] { "admin", "loco" });
    });

    options.AddPolicy("claim-policy-1", policy =>
    {
        policy.RequireClaim("LastName");
    });

    options.AddPolicy("claim-policy-2", policy =>
    {
        policy.RequireClaim("LastName", new string[] { "Bommidi", "Test", "lamar" });
    });
});
    
builder.Services.AddControllers();
builder.Services.AddDbContext<AuthContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthContext"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthLogic, AuthLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
        endpoints.MapControllers();
    }
);

app.MapControllers();

app.Run();
