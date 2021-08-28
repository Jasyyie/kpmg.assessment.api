using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kpmg.Assessment.Api.Commands;
using Kpmg.Assessment.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kpmg.Assessment.Api.Controllers
{
    [ApiController]
    [Route("v1/dog")]
    public class DogController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DogController> _logger;

        public DogController(IMediator mediator, ILogger<DogController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DogDetail>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var request = new DogSearchRequest();
                var response = await _mediator.Send(request);
                return Ok(response?.Dogs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{breed}/{sub-breed?}")]
        [ProducesResponseType(typeof(DogImageResponse), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetDogImages([FromRouteAttribute] DogImageRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest();
        }
    }
}
