using System.Net.Http.Json;
using Core.BaseTests;
using Businesslogic.Dto;
using FluentAssertions;
using NUnit.Framework;

namespace Tests.ApiTests;

[TestFixture]
[Parallelizable(scope: ParallelScope.Self)]
public class ApiTestGet : BaseApiTest
{
    private HttpClient _client;
    private string _path;
    private HttpResponseMessage _response;
    [SetUp]
    public async Task Setup()
    {
        _client = new HttpClient();
        _path = "https://jsonplaceholder.typicode.com/posts/";
        try
        {
            using var response = await _client.GetAsync(_path);
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
        successfulResponse.Should().BeSuccessful("it's set to OK");
    }

    [Test]
    public void HttpResponseBody()
    {
        var users = _response.Content.ReadFromJsonAsync<List<User>>();
        Console.WriteLine(users);
    }
}