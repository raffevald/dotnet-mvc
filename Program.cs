var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    builder.Services.AddControllersWithViews();

// Data base context for DB coneção
    builder.Services.AddScoped<IDbConnection, Connection>();

// Injeção de dependecias
    builder.Services.AddScoped<IStreamRepository, StreamRepository>();
    builder.Services.AddScoped<IAtividadesRepository, AtividadesRepository>();
    builder.Services.AddScoped<IFaseRepository, FaseRepository>();
    builder.Services.AddScoped<IApontamentoRepository, ApontamentoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment()) {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
