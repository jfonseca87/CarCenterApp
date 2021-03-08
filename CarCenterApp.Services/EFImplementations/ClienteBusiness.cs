using System.Collections.Generic;
using System.Threading.Tasks;
using CarCenter.Domain.DTOs;
using CarCenter.Repository.Interfaces;
using CarCenter.Services.Interfaces;

namespace CarCenter.Services.EFImplementations
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteBusiness(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> CrearCliente(ClienteDTO entidad)
        {
            return await _clienteRepository.CrearCliente(entidad);
        }

        public async  Task<bool> EditarCliente(ClienteDTO entidad)
        {
            return await _clienteRepository.EditarCliente(entidad);
        }

        public async Task<bool> EliminarCliente(int id)
        {
            ClienteDTO cliente = await _clienteRepository.ObtenerClientePorId(id);

            if (cliente is null)
            {
                return await Task.FromResult(false);
            }

            return await _clienteRepository.EliminarCliente(cliente);
        }

        public async Task<ClienteDTO> ObtenerClientePorId(int id)
        {
            return await _clienteRepository.ObtenerClientePorId(id);
        }

        public async Task<IEnumerable<ClienteDTO>> ObtenerClientes()
        {
            return await _clienteRepository.ObtenerClientes();
        }
    }
}
