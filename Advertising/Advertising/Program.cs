using Advertising.ServiceClient;
using Advertising.Services;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCognitoIdentity();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Accounts/Login";
});

builder.Services.AddTransient<IFileUploader, S3FileUploader>();
builder.Services.AddHttpClient<IAdvertApiClient, AdvertApiClient>()
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPatternPolicy());

IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPatternPolicy()
{
    // after 3 tries, stop for 30 seconds
    return HttpPolicyExtensions.HandleTransientHttpError()
           .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));
}

IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    // Exponential delay
    return HttpPolicyExtensions.HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}

var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
