var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ServerDataHandler>();
builder.Services.AddScoped<ModelDataChanger>();
builder.Services.AddScoped<ResponseHandler>();
builder.Services.AddTransient<RequestHandler>();
builder.Services.AddScoped<ApplicationHandler>();
builder.Services.AddTransient<BaseService>();
builder.Services.AddTransient<LabelDefiner>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection")
#pragma warning disable CS0618
        .Replace("##", Decryption.Decrypt("password", "gTY3lg7k0FyGfmD8iyRVWw==")));
#pragma warning restore CS0618
});
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(20);  options.Cookie.Name = "CivilRegistrationCookie"; });
builder.Services.AddMemoryCache();
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/General/Error");
    app.UseHsts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

//app.UseMiddleware<SessionCheckMiddleware>();

app.MapControllerRoute(
    "default",
    "{controller=General}/{action=Index}");

app.Run();