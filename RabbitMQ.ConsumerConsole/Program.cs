using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaycoreFinalProject.Service.Abstract;
using PaycoreFinalProject.Service.Concrete;

namespace RabbitMQ.ConsumerConsole
{
    internal class Program
    {
        public IConfiguration Configuration { get; }
        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var consumer = host.Services.GetRequiredService<Consumer>();

            var queue = "queue";

            consumer.Start(queue);


            //var mapperConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new MappingProfile());
            //});


            //ServiceProvider serviceProvider= new ServiceCollection().AddTransient<IRabbitMQService, RabbitMQService>().
            //    AddTransient<PaycoreFinalProject.Service.Abstract.IEmailService, PaycoreFinalProject.Service.Concrete.MailService>()
            //    .AddSingleton(mapperConfig.CreateMapper())
            //                               .BuildServiceProvider();


            //IConnection connection = serviceProvider.GetService<IConnection>();
            ////IRabbitMQService rabbitMQService = serviceProvider.GetService<IRabbitMQService>();
            ////IEmailService emailService = serviceProvider.GetService<IEmailService>();


            ////Consumer consumer = new("Mails", rabbitMQService, emailService);

            ////Console.WriteLine(connection.GetType());
            //Console.ReadLine();
        }
        static IHostBuilder CreateHostBuilder(string[] args) =>Host.CreateDefaultBuilder(args).ConfigureServices((services) =>
        {
            services.AddScoped<IConfiguration>(_ =>
            new ConfigurationBuilder().AddJsonFile($"C:/Users/seyma/source/patika/PaycoreFinalProject/PaycoreFinalProjectAPI/appsettings.json").Build());

            services.AddScoped<IRabbitMQService, RabbitMQService>();
            services.AddScoped<IEmailService, MailService>();
            services.AddTransient<Consumer>();
        });
    }


}
