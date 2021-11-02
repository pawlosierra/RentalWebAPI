using AutoMapper;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental.Web.API.Application.Commands.client.AddClient;
using Rental.Web.API.Application.Commands.client.UpDateClient;
using Rental.Web.API.Application.Commands.client.DeleteClient;
using Rental.Web.API.Application.Queries.client.GetAllClients;
using Rental.Web.API.Application.Queries.client.GetClientById;
using Rental.Web.API.Domain.Entities;
using Rental.Web.API.DTOs;
using System;
using System.Threading.Tasks;

namespace Rental.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClientsController(ILogger<ClientsController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetAllClients")]
        //[HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllClients());
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetClientById/{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetById(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _mediator.Send(new GetClientById(Id));
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddNewClient")]
        //[HttpPost]
        public async Task<IActionResult> Post(ClientDTO clientDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var client = _mapper.Map<Clients>(clientDTO);
                var result = await _mediator.Send(new AddClient(client));
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("UpDateClient/{Id}")]
        public async Task<IActionResult> UpDate(ClientDTO clientDTO, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var client = _mapper.Map<Clients>(clientDTO);
                var result = await _mediator.Send(new UpDateClient(client, Id));
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpDelete("DeleteClient/{id}")]
        public async Task<IActionResult> Delete(int Id) 
        {
            try
            {
                var result = await _mediator.Send(new DeleteClient(Id));
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        
    }
}
