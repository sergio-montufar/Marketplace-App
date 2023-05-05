using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using marketplaceapp.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UserConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("marketplaceapp"));
builder.Services.AddDbContext<UserContext2>(opt => opt.UseNpgsql(connectionString));


// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    // .AddEntityFrameworkStores<ApplicationDbContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options => {
        options.AddDefaultPolicy(policy => {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });  
}

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// When in doubt, comment out redirection
// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
