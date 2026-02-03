using IPT102LaroscainBlazorWebApp.Components;
using IPT102LaroscainRepository.Interfaces;
using IPT102LaroscainRepository.Services;

var builder = WebApplication.CreateBuilder(args);

// Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register Repository
builder.Services.AddScoped<IEmployeeRepository>(sp =>
    new EmployeeRepository(connectionString!));

// Add Interactive Services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // <--- SIGURADUHING NANDITO ITO

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // <--- AT ITO RIN

app.Run();