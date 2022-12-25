using EDP;
using EDP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();



// Entity Framework Core - Managing Schemas - Migrations
// https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs
builder.Services.AddDbContext<MyDbContext>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<VoucherService>();
builder.Services.AddScoped<ClaimVoucherService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<DonationServices>();

//Session management 
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache(); //save session in memory

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

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

app.UseAuthorization();

app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
