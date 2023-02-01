using Win22_CSharp.Services;
using Newtonsoft.Json;
namespace ConsoleApp.Tests__xUnit
{
    public class FileService_Tests
    {
        FileService fileService;
        string content; public FileService_Tests()
        {
            // arrange
            fileService = new FileService();
            fileService.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content_test.json";
            content = JsonConvert.SerializeObject(new { FirstName = "Harry", LastName = "Porter", Email = "Hagworts@hmail.com", Address = "Privet Drive 55" });
        }
        [Fact]
        public void Should_Create_a_File_With_Json_Content()
        {
            // act
            fileService.Save(fileService.FilePath, content);
            string result = fileService.Read(fileService.FilePath);             
            // assert
            Assert.True(File.Exists(fileService.FilePath));
            Assert.Equal(result.Trim(), content);
        }
    }
}