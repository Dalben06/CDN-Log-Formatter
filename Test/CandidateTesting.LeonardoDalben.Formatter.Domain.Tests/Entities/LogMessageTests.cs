using CandidateTesting.LeonardoDalben.Formatter.Domain.Entities;

namespace CandidateTesting.LeonardoDalben.Formatter.Domain.Tests.Entities
{
    public class LogMessageTests
    {


        [Test]
        public void CreateLog_ValidInput_ReturnsLogMessage()
        {
            // Arrange
            string log = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2";

            // Act
            var result = LogMessage.CreateLog(log);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("312", result.ResponseSize);
            Assert.AreEqual("200", result.StatusCode);
            Assert.AreEqual("HIT", result.CacheStatus);
            Assert.AreEqual("GET", result.HttpMethod);
            Assert.AreEqual("/robots.txt", result.UrlPath);
            Assert.AreEqual("100", result.TimeTaken);
        }


        [Test]
        public void CreateLog_ValidInput_AndRoundTimeTaken_ReturnsLogMessage()
        {
            // Arrange
            string log = "312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.6";

            // Act
            var result = LogMessage.CreateLog(log);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("312", result.ResponseSize);
            Assert.AreEqual("200", result.StatusCode);
            Assert.AreEqual("HIT", result.CacheStatus);
            Assert.AreEqual("GET", result.HttpMethod);
            Assert.AreEqual("/robots.txt", result.UrlPath);
            Assert.AreEqual("101", result.TimeTaken);
        }

        [Test]
        public void CreateLog_InvalidInput_ThrowsException()
        {
            // Arrange
            string log = "Invalid log format";

            // Act & Assert
            Assert.Throws<Exception>(() => LogMessage.CreateLog(log));
        }
    }
}
