using System;
using System.Text;
using Autofac;
using Console.HashHelper.Core.Constants;
using Console.HashHelper.Modules;
using Console.HashHelper.Services;
using Microsoft.Extensions.CommandLineUtils;
using Console = System.Console;

namespace Console.HashHelper
{
    class Program
    {
        private static IContainer ApplicationContainer { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new SevicesModule());
            ApplicationContainer = builder.Build();
            var app = new CommandLineApplication();
            app.Name = "ConsoleArgs";
            app.Description = GetDescription();

            app.HelpOption("-?|-h|--help");
            var strToHash = app.Argument("stringToGetHashFrom", "String from which hash would be computed");
            var hashOption = app.Option("-ha|--hash-algorithm <algo>",
                "Supported hash function",
                CommandOptionType.SingleValue);

            //var encodingOption = app.Option("-e|--encoding <encoding>",
            //    "Supported encoding fot output(utf8)",
            //    CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                var hashOpValueStr = hashOption.Value();
                var factory = new HashTemplateFactory(ApplicationContainer);
                using (var hashTemplate = factory.GetHashTemplate(hashOpValueStr))
                {
                    var arg1 = strToHash.Value;
                    var computedHash = hashTemplate.GetHash(Encoding.UTF32.GetBytes(arg1));
                    foreach (var @byte in computedHash)
                    {
                        System.Console.Write($"{@byte} ");
                    }
                    //var hashString = Encoding.UTF32.GetString(computedHash);
                    //System.Console.WriteLine(hashString);
                }

                return 0;
            });

            //app.Command("", (command) =>
            //{
            //    command.Description = "This is the description for simple-command.";
            //    command.HelpOption("-?|-h|--help");

            //    command.OnExecute(() =>
            //    {


            //        return 0;
            //    });
            //});

            app.Execute(args);
        }

        private static string GetDescription()
        {
            StringBuilder description = new StringBuilder("Hash Helper.");
            description.AppendLine("-ha|--hash-algorithm <algo>");
            description.AppendLine("supported algos: ");
            foreach (var supportedHashFunction in HashFunctionNames.GetSupportedHashFunctions())
            {
                description.AppendLine(supportedHashFunction);
            }

            return description.ToString();
        }
    }
}
