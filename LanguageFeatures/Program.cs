var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddMvc();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    
    app.UseHsts();
}

app.UseMvcWithDefaultRoute();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();