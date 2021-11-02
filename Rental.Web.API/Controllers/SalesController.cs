using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental.Web.API.Application.Commands.sale.AddSale;
using Rental.Web.API.Application.Commands.sale.DeleteSale;
using Rental.Web.API.Application.Commands.sale.UpDateSale;
using Rental.Web.API.Application.Queries.sale.GetAllSales;
using Rental.Web.API.Application.Queries.sale.GetSaleById;
using Rental.Web.API.Domain.Entities;
using Rental.Web.API.DTOs;
using System;
using System.Threading.Tasks;

namespace Rental.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SalesController(ILogger<SalesController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetAllSales")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _mediator.Send(new GetAllSales());
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetSaleById/{Id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _mediator.Send(new GetSaleById(Id));
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("AddNewSale")]
        public async Task<IActionResult> Post(SaleDTO saleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sale = _mapper.Map<Sales>(saleDto);
                var result = await _mediator.Send(new AddSale(sale));
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("UpDateSale/{Id}")]
        public async Task<IActionResult> Put(SaleDTO saleDTO, long Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var sale = _mapper.Map<Sales>(saleDTO);
                var result = await _mediator.Send(new UpDateSale(sale, Id));
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("DeleteSale/{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteSale(Id));
                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
