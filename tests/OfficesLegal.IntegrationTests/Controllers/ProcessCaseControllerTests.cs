using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using OfficesLegal.Api;
using Xunit;
using OfficesLegal.Application.ViewModels.CouncilProcessCases;
using System.Text.Json;
using System.Text;
using AutoBogus;

namespace OfficesLegal.IntegrationTests
{
    public class ProcessCaseControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;        
        protected readonly HttpClient _httpClient;
        public ProcessCaseControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Fact]
        public async Task PostAsync_WhenInformedAllValidFields_ShouldBeStatusCodeCreated()
        {
            // Arrange
            var processCasesViewModelInput = new AutoFaker<ProcessCasesViewModelInput>();
            var content = new StringContent(JsonSerializer.Serialize(processCasesViewModelInput.Generate()), Encoding.UTF8, "application/json");

            // Act
            var httpClientRequest = await _httpClient.PostAsync($"api/v1/ProcessCase", content);

            // Assert            
            Assert.Equal(HttpStatusCode.Created, httpClientRequest.StatusCode);
        }
    }
}
