using CandidateTesting.LeonardoDalben.Formatter.Domain.Enums;

namespace CandidateTesting.LeonardoDalben.Formatter.Domain.Entities
{
    public abstract class BaseFormat
    {
        public string Name { get; set; }
        public Field[] Fields { get; protected set; }
        public DateTime Date { get; private set; }
        public string Version { get; private set; }
        public string Output { get; private set; }
        protected BaseFormat(string name, string output, string version = "1.0")
        {
            Date = DateTime.Now;
            Output = output;
            Version = version;
            Name = name;        
        }

        public abstract void InicialInfos();
    }
}
