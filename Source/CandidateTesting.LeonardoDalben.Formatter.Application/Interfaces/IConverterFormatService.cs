using CandidateTesting.LeonardoDalben.Formatter.Application.Commands;

namespace CandidateTesting.LeonardoDalben.Formatter.Application.Interfaces
{
    public interface IConverterFormatService
    {
        Task ConvertLogMessageToFormatMessage(ConvertLogMessageCommand command);
    }
}
