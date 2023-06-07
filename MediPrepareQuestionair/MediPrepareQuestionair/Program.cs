using BlazorCurrentDevice;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MediPrepareQuestionair.Data;
using MediPrepareQuestionair.Database;
using MediPrepareQuestionair.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<MediPrepareContext>();
builder.Services.AddScoped<FormServices>();
builder.Services.AddSingleton<TestDataFormService>();
builder.Services.AddScoped<IBlazorCurrentDeviceService, BlazorCurrentDeviceServices>();
builder.Services.AddScoped<ISessionIdGenerator, SessionIdGenerator>();
builder.Services.AddSingleton<AnswerCollectionService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddSingleton<InfluxDbService>();

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
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();