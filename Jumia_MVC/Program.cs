





using Jumia_MVC.Data.Stripe;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
                                 Newtonsoft.Json.ReferenceLoopHandling.Ignore);

//stripe
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));


string text = "";
builder.Services.AddCors(options =>
{
    options.AddPolicy(text,
    builder =>
    {
        builder.AllowAnyOrigin();
        //  builder.WithOrigins("url");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});


var connection = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(
    op => op.UseSqlServer(connection));

//add service
builder.Services.AddScoped<IBannerService, BannerService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
//builder.Services.AddSingleton(sc => ShoppingCart.GetShoppingCart(sc));

builder.Services.AddScoped(fp => FavoriteProduct.GetFavoriteProduct(fp));

builder.Services.AddRazorPages();
//add Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDBContext>()
                 .AddDefaultUI()
                 .AddDefaultTokenProviders();



//add secion
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});


//add localization
builder.Services.AddLocalization(options => { options.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(
    opt =>
    {
        var supportCultures = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("ar")
        };
        opt.DefaultRequestCulture = new RequestCulture("en");
        opt.SupportedCultures = supportCultures;
        opt.SupportedUICultures = supportCultures;
    }
    );

var app = builder.Build();

//add stripe 
StripeConfiguration.SetApiKey(builder.Configuration.GetSection("Stripe")["Secretkey"]);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();
app.UseSession();


app.UseAuthorization();
app.UseAuthentication();
app.UseCors(text);

var options = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(options.Value);


//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
AppDbInitializer.Seed(app);
//AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

//app.MapRazorPages();
app.UseEndpoints(e =>
{
    e.MapRazorPages();
});

app.Run();
