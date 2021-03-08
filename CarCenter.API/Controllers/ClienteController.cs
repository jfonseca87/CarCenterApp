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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBusiness _clienteBusiness;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IClienteBusiness clienteBusiness, ILogger<ClienteController> logger)
        {
            _clienteBusiness = clienteBusiness;
            _logger = logger;
        }

        [HttpGet]
        public async Task<APIResponse<IEnumerable<ClienteDTO>>> ObtenerClientes()
        {
            try
            {
                return await Task.FromResult(new APIResponse<IEnumerable<ClienteDTO>>
                {
                    ResponseNumber = (int)HttpStatusCode.OK,
                    Data = await _clienteBusiness.ObtenerClientes()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Task.FromResult(new APIResponse<IEnumerable<ClienteDTO>>
                {
                    ResponseNumber = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = ErrorConstants.MensajeErrorGenerico
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<APIResponse<ClienteDTO>> ObtenerClientePorId(int id)
        {
            try
            {
                return await Task.FromResult(new APIResponse<ClienteDTO>
                {
                    ResponseNumber = (int)HttpStatusCode.OK,
                    Data = await _clienteBusiness.ObtenerClientePorId(id)
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return await Task.FromResult(new APIResponse<ClienteDTO>
                {
                    ResponseNumber = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = ErrorConstants.MensajeErrorGenerico
                });
            }
        }

        [HttpPost()]
        public async Task<APIResponse<bool>> CrearCliente(ClienteDTO cliente)
        {
            try
            {
                return await Task.FromResult(new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.Created,
                    Data = await _clienteBusiness.CrearCliente(cliente)
                });
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
        public async Task<APIResponse<bool>> EditarCliente(ClienteDTO cliente)
        {
            try
            {
                return await Task.FromResult(new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.OK,
                    Data = await _clienteBusiness.EditarCliente(cliente)
                });
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
                return await Task.FromResult(new APIResponse<bool>
                {
                    ResponseNumber = (int)HttpStatusCode.OK,
                    Data = await _clienteBusiness.EliminarCliente(id)
                });
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
