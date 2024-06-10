using CandidateTesting.LeonardoDalben.Formatter.Application.Factories;
using CandidateTesting.LeonardoDalben.Formatter.Application.Interfaces;
using CandidateTesting.LeonardoDalben.Formatter.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateTesting.LeonardoDalben.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IConvertFactory, ConvertFactory>();
            services.AddScoped<IConverterFormatService, ConverterFormatService>();
        }
    }
}
