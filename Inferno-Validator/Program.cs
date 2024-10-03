using Inferno_Validator;
using Inferno_Validator.Firebase;
using Inferno_Validator.Models;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<PasswordManager>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSession();

// FirebaseDb setup
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
var credentials = new FirebaseCredentials();
builder.Configuration.Bind("FirebaseCredentials", credentials);
builder.Services.AddSingleton(credentials);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
