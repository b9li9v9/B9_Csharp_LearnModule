
namespace JWTWebApplication
{
    public class Program
    {
        //��Bearer�� ��������˼�� �������ߡ���Я���ˡ�
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddOrdinaryBaseAuthentication();
            //builder.Services.AddRoleBasedAuthentication();
            //builder.Services.AddPolicyBasedAuthorization();
            builder.Services.AddCustomPolicyBasedAuthorization();//û�����
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
