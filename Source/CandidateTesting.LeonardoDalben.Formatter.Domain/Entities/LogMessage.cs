namespace CandidateTesting.LeonardoDalben.Formatter.Domain.Entities
{
    public class LogMessage
    {
        public string Provider { get; set; }
        public string HttpMethod { get; set; }
        public string StatusCode { get; set; }
        public string UrlPath { get; set; }
        public string TimeTaken { get; set; }
        public string ResponseSize { get; set; }
        public string CacheStatus { get; set; }

        public static LogMessage CreateLog(string log)
        {
            var logSplited = log.Split('|');

            if (logSplited.Length != 5)
                throw new Exception("Log message no compatibles");


            var logMessage = new LogMessage();

            logMessage.ResponseSize = logSplited[0];
            logMessage.StatusCode = logSplited[1].Replace("|","");
            logMessage.CacheStatus = logSplited[2].Replace("|","");
            double.TryParse(logSplited[4], System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out var timeTaken);
            logMessage.TimeTaken = Math.Round(timeTaken).ToString();
            var messageSplited = logSplited[3].Split(" ");
            logMessage.HttpMethod = messageSplited[0].Substring(1);
            logMessage.UrlPath = messageSplited[1];

            return logMessage;
        }

    }
}
