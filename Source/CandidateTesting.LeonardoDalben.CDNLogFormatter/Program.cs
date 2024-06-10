
using CandidateTesting.LeonardoDalben.DependencyInjection;
using CandidateTesting.LeonardoDalben.Formatter.Application.Commands;
using CandidateTesting.LeonardoDalben.Formatter.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
DependencyInjection.RegisterServices(services);

var provider = services.BuildServiceProvider();

if(args.Length < 2)
{
    Console.WriteLine("Send 2 Parameters to work. First Parameter is Source URL and Second Parameter is Target.");
    Console.ReadKey();
    return;
}

var command = new ConvertLogMessageCommand(args[0], args[1], args.Length <= 2 ? "MINHA CDN" : args[2]);
var convertService = provider.GetRequiredService<IConverterFormatService>();
await convertService.ConvertLogMessageToFormatMessage(command);
Console.WriteLine("File has been finished");


