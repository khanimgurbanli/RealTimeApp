using MessageApp.Business;
using MessageApp.Hubs;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials()
                  .SetIsOriginAllowed(opt => true);
        }));

        builder.Services.AddSignalR();
        builder.Services.AddControllers();
        builder.Services.AddScoped<HubBusiness>();

        var app = builder.Build();

        app.UseCors();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<HubAction>("/hubaction");
            endpoints.MapControllers();
        });

        app.Run();
    }
}
