
namespace JWTWebApplication
{
    public class Program
    {
        //“Bearer” 常见的意思是 “持有者”“携带人”
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddOrdinaryBaseAuthentication();
            //builder.Services.AddRoleBasedAuthentication();
            //builder.Services.AddPolicyBasedAuthorization();
            builder.Services.AddCustomPolicyBasedAuthorization();//没搞清楚
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
