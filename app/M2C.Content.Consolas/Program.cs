using M2C.Content.Data.MongoDb;
using M2C.Content.Model;
using M2C.Core;
using M2C.Core.Abstractions;
using M2C.Data.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace M2C.Content.Consolas
{
    class Program
    {
        static IConfigurationRoot configuration;
        static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();

            Console.WriteLine("ready...");
            Console.ReadLine();
            Execute();
            Console.WriteLine("done.");
            Console.ReadLine();

            Console.WriteLine("Hello World!");

        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new LoggerFactory().AddConsole().AddDebug());
            services.AddLogging();
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configuration = builder.Build();
            services.AddOptions();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();

            services.AddTransient<IDataService<ContentItem>, ContentItemDataService>();

        }



        private static void Execute()
        {
        }
        private static IDataService<T> GetService<T>() where T : class, new()
        {
            IDataService<T> service = serviceProvider.GetService<IDataService<T>>();
            return service;
        }

        private static void Get()
        {

            var service = GetService<ContentItem>();
            var response = service.Get(null);
            Console.WriteLine($"response: {response.IsOkay}");
            foreach (var item in response)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void Get(int id)
        {
            var service = GetService<ContentItem>();
            Parameters p = new Parameters("id", id);
            var response = service.Get(p);
            Console.WriteLine($"response: {response.IsOkay}");
            if (response.IsOkay)
            {
                Console.WriteLine(response.Model.ToString());
            }
            else
            {
                Console.WriteLine(response.Status.Message);
                Console.WriteLine(response.Status.SystemMessage);
            }
        }

        private static void Post(int count)
        {
            var service = GetService<ContentItem>();
            int x = 0;
            foreach (var item in GenerateContent(count))
            {
                var response = service.Post(item);
                Console.WriteLine($"{++x} of {count} : {response.Status.HttpCode}");
            }
        }
        private static IEnumerable<ContentItem> GenerateContent(int count)
        {
            List<ContentItem> list = new List<ContentItem>();

            for (int i = 1; i <= count; i++)
            {
                string s = $"{Guid.NewGuid().ToString().Substring(0, 4)}-10{i}";
                list.Add(new ContentItem()
                {
                    Display = $"Content Display #{s}"
                    ,
                    Body = $"Body for {s}"
                    ,
                    Mime = "text/plain"
                    ,
                    Tags = GenerateTags(i)
                    ,
                    CreatedBy = "bnelson"
                });
            }



            return list;
        }

        private static List<Tag> GenerateTags(int i)
        {
            List<Tag> list = new List<Tag>();
            list.Add(new Tag() { Key = "createdat", Value = DateTime.Now });
            list.Add(new Tag() { Key = "scope", Value = "public" });
            list.Add(Tag.Parse(Guid.NewGuid().ToString().Substring(0, 3)));
            list.Add(Tag.Parse(Guid.NewGuid().ToString().Substring(0, 3)));

            return list;
        }


    }
}