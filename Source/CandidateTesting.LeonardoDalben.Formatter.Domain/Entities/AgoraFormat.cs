using CandidateTesting.LeonardoDalben.Formatter.Domain.Enums;
using CandidateTesting.LeonardoDalben.Formatter.Domain.Extension;
using CandidateTesting.LeonardoDalben.Formatter.Domain.Interfaces;

namespace CandidateTesting.LeonardoDalben.Formatter.Domain.Entities
{
    public class AgoraFormat : BaseFormat, IFormat
    {

        public AgoraFormat(string name,string output, string version = "1.0") : base(name,output, version)
        {
            Fields = new Field[] {
                    Field.Provider,
                    Field.HttpMethod,
                    Field.StatusCode,
                    Field.UrlPath,
                    Field.TimeTaken,
                    Field.ResponseSize,
                    Field.CacheStatus,
                };
            InicialInfos();
        }

        public override void InicialInfos()
        {
            using (StreamWriter outputFile = new StreamWriter(this.Output))
            {
                outputFile.WriteLine($"#Version: {Version}");
                outputFile.WriteLine($"#Date: {Date.ToString("dd/MM/yyyy HH:mm:ss")}");
                outputFile.WriteLine($"#Fields: {string.Join(' ', Fields.Select(Name => Name.GetDescription()))}");
            }
        }

        public void WriteLog(LogMessage logMessage)
        {
            using (StreamWriter outputFile = new StreamWriter(this.Output,true))
                outputFile.WriteLine(FormatLogMessage(logMessage));
        }

        private string FormatLogMessage(LogMessage logMessage)
        {
            var listFields = new List<string>();
            foreach (var field in Fields)
            {
                if (field == Field.Provider)
                    listFields.Add($"\"{Name}\"");
                else
                    listFields.Add(logMessage.GetValueByPropertyField(field).ToString() ?? string.Empty);
            }
            return string.Join(' ', listFields);
        }
    }
}
