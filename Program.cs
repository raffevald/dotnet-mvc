var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Data base context for DB coneção
    // builder.Services.AddScoped<Connection>();
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    builder.Services.AddDbContext<dotnet_mvc.Data.DbContextAplication>(options => { 
        options.UseNpgsql(builder.Configuration.GetConnectionString("Default")); });
    
// Injeção de dependecias
    // builder.Services.AddScoped<IApontamentoRepository, ApontamentoRepository>();
    builder.Services.AddScoped<IFaseRepository, FaseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
