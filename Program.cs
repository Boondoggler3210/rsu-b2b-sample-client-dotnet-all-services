﻿using Microsoft.Extensions.Configuration;
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
            string SENummer = configuration["SENummer"];
            string virksomhedKalenderHentDateFrom = configuration.GetSection("VirksomhedKalenderHent")["DateFrom"];
            string virksomhedKalenderHentDateTo = configuration.GetSection("VirksomhedKalenderHent")["DateTo"];
            Angivelsesafgifter ModtagMomsangivelseForeloebigReturnValues = configuration.GetSection("ModtagMomsangivelseForeloebig").GetSection("Angivelsesafgifter").Get<Angivelsesafgifter>();
            string modtagMomsangivelseForeloebigDateFrom = configuration.GetSection("ModtagMomsangivelseForeLoebig")["DateFrom"];
            string modtagMomsangivelseForeloebigDateTo = configuration.GetSection("ModtagMomsangivelseForeloebig")["DateTo"];
            string momsangivelseKvitteringHentTransaktionId = configuration.GetSection("MomsangivelseKvitteringHent")["TransaktionId"];
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
                Console.Write("Enter a number to call the Service:"); ;

                var command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        await client.CallService(new VirksomhedKalenderHentWriter(SENummer, virksomhedKalenderHentDateFrom, virksomhedKalenderHentDateTo), endpoints.VirksomhedKalenderHent);
                        Console.WriteLine("Finished");
                        break;
                    case "2":
                        await client.CallService(new ModtagMomsangivelseForeloebigWriter(SENummer, configuration.GetSection("ModtagMomsangivelseForeLoebig")["DateFrom"], configuration.GetSection("ModtagMomsangivelseForeloebig")["DateTo"], ModtagMomsangivelseForeloebigReturnValues), endpoints.ModtagMomsangivelseForeloebig);
                        Console.WriteLine("Finished");
                        break;
                    case "3":
                        await client.CallService(new MomsangivelseKvitteringHentWriter(SENummer, momsangivelseKvitteringHentTransaktionId), endpoints.MomsangivelseKvitteringHent);
                        Console.WriteLine("Finished");
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
