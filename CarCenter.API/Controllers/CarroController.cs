using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CarCenter.API.APIModels;
using CarCenter.Domain.DTOs;
using CarCenter.Services.Interfaces;
using CarCenter.Utils.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CarCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroBusiness _carroBusiness;
        private readonly ILogger<CarroController> _logger;

        public CarroController(ICarroBusiness carroBusiness, ILogger<CarroController> logger)
        {
            _carroBusiness = carroBusiness;
            _logger = logger;
        }

        [HttpGet("{id}/carros")]
        public async Task<APIResponse<IEnumerable<CarroDTO>>> ObtenerCarrosPorCliente(int id)
        {
            try
            {
                return new APIResponse<IEnumerable<CarroDTO>>
                {
                    ResponseNumber = (int)HttpStatusCode.OK,
                    Data = await _carroBusiness.ObtenerCarrosPorCliente(id)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Task.FromResult(new APIResponse<IEnumerable<CarroDTO>>
                {
                    ResponseNumber = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = ErrorConstants.MensajeErrorGenerico
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<APIResponse<CarroDTO>> ObtenerCarroPorId(int id)
        {
            try
            {
                return await Task.FromResult(new APIResponse<CarroDTO>
                {
                    ResponseNumber = (int)HttpStatusCode.OK,
                    Data = await _carroBusiness.ObtenerCarrosPorId(id)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new APIResponse<CarroDTO>
                {
                    ResponseNumber = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = ErrorConstants.MensajeErrorGenerico
                };
            }
        }

        [HttpPost()]
        public async Task<APIResponse<bool>> CrearCliente(CarroDTO carro)
        {
            try
            {
                return new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.Created,
                    Data = await _carroBusiness.CrearCarro(carro)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Task.FromResult(new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = ErrorConstants.MensajeErrorGenerico
                });
            }
        }

        [HttpPut()]
        public async Task<APIResponse<bool>> EditarCliente(CarroDTO carro)
        {
            try
            {
                return new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.OK,
                    Data = await _carroBusiness.EditarCarro(carro)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Task.FromResult(new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = ErrorConstants.MensajeErrorGenerico
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<APIResponse<bool>> EliminarCliente(int id)
        {
            try
            {
                return new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.OK,
                    Data = await _carroBusiness.EliminarCarro(id)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Task.FromResult(new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = ErrorConstants.MensajeErrorGenerico
                });
            }
        }
    }
}
