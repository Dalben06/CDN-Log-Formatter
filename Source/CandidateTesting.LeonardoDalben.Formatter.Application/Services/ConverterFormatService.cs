using CandidateTesting.LeonardoDalben.Formatter.Application.Commands;
using CandidateTesting.LeonardoDalben.Formatter.Application.Interfaces;
using CandidateTesting.LeonardoDalben.Formatter.Domain.Entities;

namespace CandidateTesting.LeonardoDalben.Formatter.Application.Services
{
    public class ConverterFormatService : IConverterFormatService
    {
        private readonly IConvertFactory _convertFactory;

        public ConverterFormatService(IConvertFactory convertFactory)
        {
            _convertFactory = convertFactory;
        }

        public async Task ConvertLogMessageToFormatMessage(ConvertLogMessageCommand command)
        {
            try
            {
                if (command is null)
                    throw new ArgumentNullException(nameof(command));

                if (string.IsNullOrEmpty(command.Input))
                    throw new ArgumentNullException(nameof(command.Input));

                if (string.IsNullOrEmpty(command.Output))
                    throw new ArgumentNullException(nameof(command.Output));

                if (string.IsNullOrEmpty(command.ProviderName))
                    command.ProviderName = "Unknown Provider";


                var format = _convertFactory.GetFormat(command);
                if (command.Input.StartsWith("http"))
                {
                    using var client = new HttpClient();
                    using var response = await client.GetAsync(command.Input, HttpCompletionOption.ResponseHeadersRead);
                    if (!response.IsSuccessStatusCode)
                        throw new Exception("It wasn't possible to get informations about url received");

                    using var stream = await response.Content.ReadAsStreamAsync();
                    using var reader = new StreamReader(stream);
                    while (!reader.EndOfStream)
                    {
                        string? line = await reader.ReadLineAsync();
                        format.WriteLog(LogMessage.CreateLog(line ?? string.Empty));
                    }
                }
                else
                {
                    if (!File.Exists(command.Input)) throw new FileNotFoundException("Input not found!");

                    using var reader = new StreamReader(command.Input);

                    string line = string.Empty;
                    while ((line = reader?.ReadLine()) != null)
                        format.WriteLog(LogMessage.CreateLog(line ?? string.Empty));

                }
            }
            catch (FileNotFoundException file)
            {
                throw file;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
