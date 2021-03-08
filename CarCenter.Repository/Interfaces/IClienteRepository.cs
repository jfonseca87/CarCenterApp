using System.Collections.Generic;
using System.Threading.Tasks;
using CarCenter.Domain.DTOs;

namespace CarCenter.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<ClienteDTO>> ObtenerClientes();
        Task<ClienteDTO> ObtenerClientePorId(int id);
        Task<bool> CrearCliente(ClienteDTO entidad);
        Task<bool> EditarCliente(ClienteDTO entidad);
        Task<bool> EliminarCliente(ClienteDTO entidad);
    }
}
