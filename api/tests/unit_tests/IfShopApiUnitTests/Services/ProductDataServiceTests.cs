using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Xunit;
using IfShopApi.Services;
using IfShopApi.Interfaces;
using IfShopApi.Models;

namespace IfShopApiUnitTests.Services
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
    public class ProductDataServiceTests
    {

        [Fact]
        public async Task GetProductsAsync_Success()
        {
            // Arrange
            var expectedProductList = new ProductList(); // You need to define expected product list

            // Mock HttpClientHandler
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(expectedProductList))
                });

            // Use HttpClient with the mocked handler
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://dummyjson.com/")
            };

            // Mock IHttpClientFactory
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(factory => factory.CreateClient("DummyJsonApi")).Returns(httpClient);

            var productDataService = new ProductDataService(httpClientFactoryMock.Object);

            // Act
            var productList = await productDataService.GetProductsAsync();

            // Assert
            Assert.NotNull(productList);
        }

        [Fact]
        public async Task GetProductsAsync_HttpError()
        {
            // Arrange
            var expectedExceptionMessage = "Error getting products API";

            // Mock HttpClientHandler
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ThrowsAsync(new HttpRequestException(expectedExceptionMessage));

            // Use HttpClient with the mocked handler
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://dummyjson.com/")
            };

            // Mock IHttpClientFactory
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock.Setup(factory => factory.CreateClient("DummyJsonApi")).Returns(httpClient);

            var productDataService = new ProductDataService(httpClientFactoryMock.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => productDataService.GetProductsAsync());
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }
    }
}

