using CandidateTesting.LeonardoDalben.Formatter.Domain.Entities;

namespace CandidateTesting.LeonardoDalben.Formatter.Domain.Tests.Entities
{

    public class AgoraFormatTests
    {


        [Test]
        public void Convert_Successfuly_To_AgoraFormat() 
        {
            // Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Outputs", "SuccessfulyFile.txt");
            var agoraFormat = new AgoraFormat("CDN Successfuly", path);
            var logMessages = new List<LogMessage>() 
            {
                LogMessage.CreateLog("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2"),
                LogMessage.CreateLog("101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4"),
                LogMessage.CreateLog("199|404|MISS|\"GET /not-found HTTP/1.1\"|142.9"),
                LogMessage.CreateLog("312|200|REFRESH_HIT|\"GET /robots.txt HTTP/1.1\"|245.1"),
            };

            foreach (var log in logMessages)
                agoraFormat.WriteLog(log);

            // Act
            var shouldBe = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SuccessfulyFiles", "AgoraFormatSuccefuly.txt"));
            shouldBe = shouldBe.Replace("{0}", agoraFormat.Date.ToString("dd/MM/yyyy HH:mm:ss"));
            var result = File.ReadAllText(path);
            var tst = string.Compare(shouldBe, result,StringComparison.InvariantCultureIgnoreCase);

            // Assert
            Assert.IsTrue(tst == 0);
        }

        [Test]
        public void Convert_FailedFile_To_AgoraFormat()
        {
            // Arrange
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Outputs", "FailedFile.txt");
            var agoraFormat = new AgoraFormat("CDN Successfuly", path);
            var logMessages = new List<LogMessage>()
            {
                LogMessage.CreateLog("312|200|HIT|\"GET /robots.txt HTTP/1.1\"|100.2"),
                LogMessage.CreateLog("101|200|MISS|\"POST /myImages HTTP/1.1\"|319.4"),
                LogMessage.CreateLog("199|404|MISS|\"GET /not-found HTTP/1.1\"|144"),
                LogMessage.CreateLog("312|200|REFRESH_HIT|\"GET /robots.txt HTTP/1.1\"|245.1"),
            };

            foreach (var log in logMessages)
                agoraFormat.WriteLog(log);

            // Act
            var shouldBe = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SuccessfulyFiles", "AgoraFormatSuccefuly.txt"));
            shouldBe = shouldBe.Replace("{0}", agoraFormat.Date.ToString("dd/MM/yyyy HH:mm:ss"));
            var result = File.ReadAllText(path);
            var tst = string.Compare(shouldBe, result, StringComparison.CurrentCulture);

            // Assert
            Assert.IsTrue(tst == -1);
        }
    }
}
