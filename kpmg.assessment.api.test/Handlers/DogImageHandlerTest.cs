using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Kpmg.Assessment.Api.Services;
using Kpmg.Assessment.Api.Commands;
using Kpmg.Assessment.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Kpmg.Assessment.Api.Handlers;

namespace Kpmg.Assessment.Api.Test.Handlers
{
    /// <summary>
    /// controller test Exercise 1
    /// </summary>
    [TestClass]
    public class DogImageHandlerTest
    {
        const string jsonResponse = "{\"message\":[\"https://images.dog.ceo/breeds/bulldog-french/IMG_0846.jpg\",\"https://images.dog.ceo/breeds/bulldog-french/IMG_1657.jpg\",\"https://images.dog.ceo/breeds/bulldog-french/n02108915_10204.jpg\"],\"status\":\"success\"}";
        private DogImageHandler _dogImageHandler;

        [TestInitialize]
        public void Initialize()
        {
            // arrange api response
            var messageHandler = Substitute.ForPartsOf<MockHttpMessageHandler>(jsonResponse, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);
            var httpClentFactory = Substitute.For<IHttpClientFactory>();
            httpClentFactory.CreateClient().Returns(httpClient);

            var dogService = Substitute.ForPartsOf<DogService>(httpClentFactory);
            var dogImageHandlerLogger = Substitute.For<ILogger<DogImageHandler>>();

            _dogImageHandler = Substitute.ForPartsOf<DogImageHandler>(dogService, dogImageHandlerLogger);
        }

        [TestMethod]
        public async Task Should_Return_ListOfImages()
        {
            // act
            var response = await _dogImageHandler.Handle(new DogImageRequest(), default(CancellationToken));

            // assert
            Assert.IsNotNull(response);
            Assert.AreEqual(3, response.ImageUrls.Count());
        }
    }
}