using CandidateTesting.LeonardoDalben.Formatter.Domain.Enums;

namespace CandidateTesting.LeonardoDalben.Formatter.Application.Commands
{
    public class ConvertLogMessageCommand
    {
        public ConvertLogMessageCommand(string input, string output, string providerName, TypeFormat type = TypeFormat.Agora)
        {
            Input = input;
            Output = output;
            ProviderName = providerName;
            Type = type;
        }

        public string Input { get; set; }
        public string Output { get; set; }
        public string ProviderName { get; set; }
        public TypeFormat Type { get; set; } = TypeFormat.Agora;
    }
}
