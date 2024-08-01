using MVC.AutoMapper;
using MVC.Extentions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.InjectServices();
builder.Services.InjectRepositories();
builder.Services.ConfigCookie();
builder.Services.AddAutoMapper(typeof(MapperProfile));
//builder.Logging.LoggerConfigure(builder.Configuration);

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
//app.UseMiddleware<ReqLogMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();