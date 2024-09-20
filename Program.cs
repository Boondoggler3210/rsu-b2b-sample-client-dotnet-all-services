using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace UFSTWSSecuritySample
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("testvalues.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets<Program>()
                .Build();

            Settings settings = configuration.GetSection("Settings").Get<Settings>();
            Endpoints endpoints = configuration.GetSection("Endpoints").Get<Endpoints>();

            //Console.WriteLine($"Path to PCKS#12 file = {settings.PathPKCS12}");
            //Console.WriteLine($"Path to PEM file = {settings.PathPEM}");
            //Console.WriteLine($"VirksomhedKalenderHent = {endpoints.VirksomhedKalenderHent}");
            //Console.WriteLine($"ModtagMomsangivelseForeloebig = {endpoints.ModtagMomsangivelseForeloebig}");
            //Console.WriteLine($"MomsangivelseKvitteringHent = {endpoints.MomsangivelseKvitteringHent}");

            if (!File.Exists(settings.PathPKCS12))
            {
                Console.WriteLine("Cannot find " + settings.PathPKCS12);
                Console.WriteLine("Aborting run...");
                return;
            }

            if (!File.Exists(settings.PathPEM))
            {
                Console.WriteLine("Cannot find " + settings.PathPEM);
                Console.WriteLine("Aborting run...");
                return;
            }

            IApiClient client = new ApiClient(settings);

            while (true)
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("1 - VirksomhedKalenderHent (Company Calendar Get)");
                Console.WriteLine("2 - ModtagMomsangivelseForeloebig (Recieve Draft VAT Returns)");
                Console.WriteLine("3 - MomsangivelseKvitteringHent (VAT Receipt Get)");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.Write("Enter a number to call the Service: "); 

                var command = Console.ReadLine();
                Guid transactionId;
                switch (command)
                {
                    case "1":
                        transactionId = Guid.NewGuid();
                        await client.CallService(new VirksomhedKalenderHentWriter(configuration["SENummer"], configuration.GetSection("VirksomhedKalenderHent")["DateFrom"], configuration.GetSection("VirksomhedKalenderHent")["DateTo"], transactionId), endpoints.VirksomhedKalenderHent, transactionId);
                        break;
                    case "2":
                        transactionId = Guid.NewGuid();
                        await client.CallService(new ModtagMomsangivelseForeloebigWriter(configuration["SENummer"], configuration.GetSection("ModtagMomsangivelseForeLoebig")["DateFrom"], configuration.GetSection("ModtagMomsangivelseForeloebig")["DateTo"], configuration.GetSection("ModtagMomsangivelseForeloebig").GetSection("Angivelsesafgifter").Get<Angivelsesafgifter>(), transactionId), endpoints.ModtagMomsangivelseForeloebig, transactionId);
                        break;
                    case "3":
                        transactionId = Guid.NewGuid();
                        await client.CallService(new MomsangivelseKvitteringHentWriter(configuration["SENummer"], configuration.GetSection("MomsangivelseKvitteringHent")["TransaktionId"], transactionId), endpoints.MomsangivelseKvitteringHent, transactionId);
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        Console.WriteLine("Enter a number to call a service.");
                        break;
                }


            }

        }
    }
}
