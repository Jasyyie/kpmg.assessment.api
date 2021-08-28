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
    public class DogSearchHandlerTest
    {
        const string jsonResponse = "{\"message\":{\"african\":[],\"bulldog\":[\"boston\",\"english\",\"french\"]},\"status\":\"success\"}";
        private DogSearchHandler _dogSearchHandler;

        [TestInitialize]
        public void Initialize()
        {
            // arrange api response
            var messageHandler = Substitute.ForPartsOf<MockHttpMessageHandler>(jsonResponse, HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);
            var httpClentFactory = Substitute.For<IHttpClientFactory>();
            httpClentFactory.CreateClient().Returns(httpClient);

            var dogService = Substitute.ForPartsOf<DogService>(httpClentFactory);
            var dogSearchHandlerLogger = Substitute.For<ILogger<DogSearchHandler>>();

            _dogSearchHandler = Substitute.ForPartsOf<DogSearchHandler>(dogService, dogSearchHandlerLogger);
        }

        [TestMethod]
        public async Task Should_Return_ListOfDogs()
        {
            // act
            var response = await _dogSearchHandler.Handle(new DogSearchRequest(), default(CancellationToken));

            // assert
            Assert.IsNotNull(response);
            Assert.AreEqual(4, response.Dogs.Count());
        }
    }
}