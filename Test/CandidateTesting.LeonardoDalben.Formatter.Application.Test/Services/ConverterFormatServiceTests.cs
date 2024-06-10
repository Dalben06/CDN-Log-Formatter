using CandidateTesting.LeonardoDalben.Formatter.Application.Commands;
using CandidateTesting.LeonardoDalben.Formatter.Application.Factories;
using CandidateTesting.LeonardoDalben.Formatter.Application.Interfaces;
using CandidateTesting.LeonardoDalben.Formatter.Application.Services;

namespace CandidateTesting.LeonardoDalben.Formatter.Application.Test.Services
{
    public class ConverterFormatServiceTests
    {
        protected IConverterFormatService _converterFormatService;

        [SetUp]
        public void Setup() {
            _converterFormatService = new ConverterFormatService(new ConvertFactory()); 
        }


        [Test]
        public async Task CanConvert_Local_File_Successful()
        {
            //Arrange
            var output = Path.Combine(Directory.GetCurrentDirectory(), "Results", "TestSuccessfulyLocal.txt");
            var commmand = new ConvertLogMessageCommand(Path.Combine(Directory.GetCurrentDirectory(), "Mocks", "InputMock.txt"), output, "TestOne CDN");

            // act
            await _converterFormatService.ConvertLogMessageToFormatMessage(commmand);
            var result = File.ReadAllLines(output);

            //Assert
            Assert.Greater(result.Length,5);
        }

        [Test]
        public async Task CanConvert_Remote_File_Successful()
        {
            //Arrange
            var output = Path.Combine(Directory.GetCurrentDirectory(), "Results", "TestSuccessfulyRemote.txt");
            var commmand = new ConvertLogMessageCommand("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", output, "TestOne CDN");
           


            // act
            await _converterFormatService.ConvertLogMessageToFormatMessage(commmand);
            var result = File.ReadAllLines(output);

            //Assert
            Assert.Greater(result.Length, 5);
        }


        [Test]
        public void Failed_Convert_No_Input()
        {
            //Arrange
            var output = Path.Combine(Directory.GetCurrentDirectory(), "Results", "TestSuccessfuly.txt");
            var commmand = new ConvertLogMessageCommand(null, output, "XPTO");


            //act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _converterFormatService.ConvertLogMessageToFormatMessage(commmand));
        }

        [Test]
        public void Failed_Convert_No_Output()
        {
            //Arrange
            var output = Path.Combine(Directory.GetCurrentDirectory(), "Results", "TestSuccessfuly.txt");
            var commmand = new ConvertLogMessageCommand("OnlyTest",null,"XPTO");

            //act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _converterFormatService.ConvertLogMessageToFormatMessage(commmand));
        }


        [Test]
        public void Failed_Convert_Not_Found_Source_Input()
        {
            //Arrange
            var output = Path.Combine(Directory.GetCurrentDirectory(), "Results", "TestSuccessfuly.txt");
            var commmand = new ConvertLogMessageCommand("OnlyTest", output, "XPTO");


            //act and Assert
            Assert.ThrowsAsync<FileNotFoundException>(async () => await _converterFormatService.ConvertLogMessageToFormatMessage(commmand));
        }

        [Test]
        public void Failed_Convert_Not_Found_Source_Http_Input()
        {
            //Arrange
            var output = Path.Combine(Directory.GetCurrentDirectory(), "Results", "TestSuccessfuly.txt");
            var commmand = new ConvertLogMessageCommand("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-02.txt", output, "XPTO");


            //act and Assert
            Assert.ThrowsAsync<Exception>(async () => await _converterFormatService.ConvertLogMessageToFormatMessage(commmand));
        }

    }
}
