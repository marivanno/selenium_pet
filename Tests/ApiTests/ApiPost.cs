using System.Net.Http.Headers;
using System.Text;
using Businesslogic.Dto;
using Core.BaseTests;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests.ApiTests;

public class ApiPost : BaseApiTest
{
    private HttpClient _client;
    private string _path;
    private HttpResponseMessage _response;
    private string _authToken;
    
    [SetUp]
    public async Task Setup()
    {
        _client = new HttpClient();
        _path = "https://gorest.co.in/public/v2/users";
        _authToken = "e8606a0181f096298a52253b714ff29f5324b475b01826273ed1caf3a0f56c26";
        try
        {
            User ivanUser = new User("Ivan Banan", "banan@gmail.com", "Male", "active");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            var postContent = new StringContent(JsonConvert.SerializeObject(ivanUser), Encoding.UTF8,
                "application/json");
            using var response = await _client.PostAsync(_path, postContent);
            _response = response;
        }
        catch (Exception error)
        {
            logger.Error($"{error.Message}");
        }
    }
    
    [Test]
    public void StatusCodeOfTheObtainedResponse()
    {
        var successfulResponse = new HttpResponseMessage(_response.StatusCode);
        /*successfulResponse.Should().BeSuccessful("it's set to OK");*/
    }
}