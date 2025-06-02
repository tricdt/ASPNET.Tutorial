using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
.AddCookie("Cookies")
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = "https://localhost:5000";
    options.ClientId = "clientApp";
    options.ClientSecret = "secret";
    options.ResponseType = "code";

    // Tùy chỉnh URL callback
    options.CallbackPath = "/custom-callback";
    
    // Tùy chỉnh URL logout callback
    options.SignedOutCallbackPath = "/custom-logout-callback";

    // Cấu hình scope
    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("resourceApi");

    // Lấy claims từ user info endpoint
    options.GetClaimsFromUserInfoEndpoint = true;

    // Không đổi tên claim types
    options.MapInboundClaims = false;

    // Lưu tokens
    options.SaveTokens = true;

    // Tùy chỉnh thời gian token
    options.UseTokenLifetime = true;
    options.UsePkce = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
