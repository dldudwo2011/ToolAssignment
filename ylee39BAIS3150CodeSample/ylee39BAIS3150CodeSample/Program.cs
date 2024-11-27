var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles(); // ADD FOR WWWROOT 
app.UseRouting();

app.MapRazorPages();

//app.MapGet("/", () => "Hello World!");

app.Run();