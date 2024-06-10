using CandidateTesting.LeonardoDalben.Formatter.Application.Commands;
using CandidateTesting.LeonardoDalben.Formatter.Domain.Interfaces;

namespace CandidateTesting.LeonardoDalben.Formatter.Application.Interfaces
{
    public interface IConvertFactory
    {
        IFormat GetFormat(ConvertLogMessageCommand converterFormat);
    }
}
