using Microsoft.EntityFrameworkCore;
using UnMaker.Components;
using UnMaker.Components.Data;
using Cropper.Blazor.Extensions;
using Microsoft.AspNetCore.Mvc.RazorPages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UnMakerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("UnMakerContext") ?? throw new InvalidOperationException("Connection string 'UnMakerContext' not found.")));
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddRazorPages();

var maxBufferSize = 100 * 1024 * 1024;
builder.Services.AddServerSideBlazor().AddHubOptions(opt => { opt.MaximumReceiveMessageSize = maxBufferSize; });
builder.Services.AddBlazorBootstrap();
builder.Services.AddCropper();

var imgurClientId = builder.Configuration["Imgur:ClientId"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapGet("/DeckEditor", () => imgurClientId);
app.Run();
