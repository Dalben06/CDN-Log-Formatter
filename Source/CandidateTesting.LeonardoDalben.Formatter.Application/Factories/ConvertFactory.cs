using CandidateTesting.LeonardoDalben.Formatter.Application.Commands;
using CandidateTesting.LeonardoDalben.Formatter.Application.Interfaces;
using CandidateTesting.LeonardoDalben.Formatter.Domain.Entities;
using CandidateTesting.LeonardoDalben.Formatter.Domain.Enums;
using CandidateTesting.LeonardoDalben.Formatter.Domain.Interfaces;

namespace CandidateTesting.LeonardoDalben.Formatter.Application.Factories
{
    public class ConvertFactory : IConvertFactory
    {
        public IFormat GetFormat(ConvertLogMessageCommand command)
        {
            switch (command.Type)
            {
                case TypeFormat.Agora:
                default:
                    return new AgoraFormat(command.ProviderName,command.Output);
            }
        }
    }
}
