using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using kpmg.assessment.api.commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kpmg.assessment.api.Controllers
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
        public async Task<ActionResult<List<DogDetail>>> Get()
        {
            try
            {
                var request = new DogSearchRequest();
                var response = await _mediator.Send(request);
                return response.Dogs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("{breed}/{sub-breed?}")]
        public async Task<ActionResult<string>> GetByBreed([FromRouteAttribute] DogBreedRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest();
        }
    }
}
